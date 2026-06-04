using Microsoft.Extensions.Caching.Distributed;
using organumator.Dtos;
using organumator.Interfaces;
using organumator.Models;
using organumator.Repositories;
using System.Text.Json;

namespace organumator.Repositories.Cached
{
    public class CachedLivergolPillTakingRepository(
        LivergolPillTakingRepository inner,
        IDistributedCache cache) : ILivergolPillTakingRepository
    {
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        private static string PageKey(int pageNumber, int pageSize) =>
            $"LivergolPillTakings:page:{pageNumber}:size:{pageSize}";

        public async Task<PagedResult<LivergolPillTakingModel>> GetAllLivergolPillTakingsPagedAsync(int pageNumber, int pageSize)
        {
            var key = PageKey(pageNumber, pageSize);
            var cached = await cache.GetStringAsync(key);
            if (cached is not null)
                return JsonSerializer.Deserialize<PagedResult<LivergolPillTakingModel>>(cached)!;

            var result = await inner.GetAllLivergolPillTakingsPagedAsync(pageNumber, pageSize);
            await cache.SetStringAsync(key, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<LivergolPillTakingModel> GetLivergolPillTakingByIdAsync(int id)
            => inner.GetLivergolPillTakingByIdAsync(id);

        public async Task<LivergolPillTakingModel> AddLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking)
        {
            var result = await inner.AddLivergolPillTakingAsync(livergolPillTaking);
            await InvalidatePageCachesAsync();
            return result;
        }

        public async Task<LivergolPillTakingModel> UpdateLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking)
        {
            var result = await inner.UpdateLivergolPillTakingAsync(livergolPillTaking);
            await InvalidatePageCachesAsync();
            return result;
        }

        public async Task DeleteLivergolPillTakingAsync(int id)
        {
            await inner.DeleteLivergolPillTakingAsync(id);
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
