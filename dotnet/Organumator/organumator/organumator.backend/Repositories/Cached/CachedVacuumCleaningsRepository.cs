using Microsoft.Extensions.Caching.Distributed;
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
        private const string AllKey = "VacuumCleanings:all";
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        public async Task<List<VacuumCleanings>> GetAllVacuumCleaningsAsync()
        {
            var cached = await cache.GetStringAsync(AllKey);
            if (cached is not null)
                return JsonSerializer.Deserialize<List<VacuumCleanings>>(cached)!;

            var result = await inner.GetAllVacuumCleaningsAsync();
            await cache.SetStringAsync(AllKey, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<VacuumCleanings> GetVacuumCleaningsByIdAsync(int id)
            => inner.GetVacuumCleaningsByIdAsync(id);

        public async Task<VacuumCleanings> AddVacuumCleaningsAsync(VacuumCleanings vacuumCleanings)
        {
            var result = await inner.AddVacuumCleaningsAsync(vacuumCleanings);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task<VacuumCleanings> UpdateVacuumCleaningsAsync(VacuumCleanings vacuumCleanings)
        {
            var result = await inner.UpdateVacuumCleaningsAsync(vacuumCleanings);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task DeleteVacuumCleaningsAsync(int id)
        {
            await inner.DeleteVacuumCleaningsAsync(id);
            await cache.RemoveAsync(AllKey);
        }
    }
}
