using Microsoft.Extensions.Caching.Distributed;
using organumator.Dtos;
using organumator.Interfaces;
using organumator.Models;
using organumator.Repositories;
using System.Text.Json;

namespace organumator.Repositories.Cached
{
    public class CachedSilvermanPillTakingRepository(
        SilvermanPillTakingRepository inner,
        IDistributedCache cache) : ISilvermanPillTakingRepository
    {
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        private static string PageKey(int pageNumber, int pageSize) =>
            $"SilvermanPillTakings:page:{pageNumber}:size:{pageSize}";

        public async Task<PagedResult<SilvermanPillTaking>> GetAllSilvermanPillTakingsPagedAsync(int pageNumber, int pageSize)
        {
            var key = PageKey(pageNumber, pageSize);
            var cached = await cache.GetStringAsync(key);
            if (cached is not null)
                return JsonSerializer.Deserialize<PagedResult<SilvermanPillTaking>>(cached)!;

            var result = await inner.GetAllSilvermanPillTakingsPagedAsync(pageNumber, pageSize);
            await cache.SetStringAsync(key, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<SilvermanPillTaking> GetSilvermanPillTakingByIdAsync(int id)
            => inner.GetSilvermanPillTakingByIdAsync(id);

        public async Task<SilvermanPillTaking> AddSilvermanPillTakingAsync(SilvermanPillTaking silvermanPillTaking)
        {
            var result = await inner.AddSilvermanPillTakingAsync(silvermanPillTaking);
            await InvalidatePageCachesAsync();
            return result;
        }

        public async Task<SilvermanPillTaking> UpdateSilvermanPillTakingAsync(SilvermanPillTaking silvermanPillTaking)
        {
            var result = await inner.UpdateSilvermanPillTakingAsync(silvermanPillTaking);
            await InvalidatePageCachesAsync();
            return result;
        }

        public async Task DeleteSilvermanPillTakingAsync(int id)
        {
            await inner.DeleteSilvermanPillTakingAsync(id);
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
