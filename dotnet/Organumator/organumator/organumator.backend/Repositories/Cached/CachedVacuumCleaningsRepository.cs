using Microsoft.Extensions.Caching.Distributed;
using organumator.Dtos;
using organumator.Interfaces;
using organumator.Models;
using organumator.Repositories;
using System.Text.Json;

namespace organumator.Repositories.Cached
{
    public class CachedVacuumCleaningsRepository(
        VacuumCleaningsRepository inner,
        IDistributedCache cache) : IVacuumCleaningsRepository
    {
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        private static string PageKey(int pageNumber, int pageSize) =>
            $"VacuumCleanings:page:{pageNumber}:size:{pageSize}";

        public async Task<PagedResult<VacuumCleanings>> GetAllVacuumCleaningsPagedAsync(int pageNumber, int pageSize)
        {
            var key = PageKey(pageNumber, pageSize);
            var cached = await cache.GetStringAsync(key);
            if (cached is not null)
                return JsonSerializer.Deserialize<PagedResult<VacuumCleanings>>(cached)!;

            var result = await inner.GetAllVacuumCleaningsPagedAsync(pageNumber, pageSize);
            await cache.SetStringAsync(key, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<VacuumCleanings> GetVacuumCleaningsByIdAsync(int id)
            => inner.GetVacuumCleaningsByIdAsync(id);

        public async Task<VacuumCleanings> AddVacuumCleaningsAsync(VacuumCleanings vacuumCleanings)
        {
            var result = await inner.AddVacuumCleaningsAsync(vacuumCleanings);
            await InvalidatePageCachesAsync();
            return result;
        }

        public async Task<VacuumCleanings> UpdateVacuumCleaningsAsync(VacuumCleanings vacuumCleanings)
        {
            var result = await inner.UpdateVacuumCleaningsAsync(vacuumCleanings);
            await InvalidatePageCachesAsync();
            return result;
        }

        public async Task DeleteVacuumCleaningsAsync(int id)
        {
            await inner.DeleteVacuumCleaningsAsync(id);
            await InvalidatePageCachesAsync();
        }

        private async Task InvalidatePageCachesAsync()
        {
            int[] commonPageSizes = [5, 8, 10, 20, 25, 50];
            var removals = new List<Task>();
            foreach (var size in commonPageSizes)
                for (var page = 1; page <= 20; page++)
                    removals.Add(cache.RemoveAsync(PageKey(page, size)));
            await Task.WhenAll(removals);
        }
    }
}
