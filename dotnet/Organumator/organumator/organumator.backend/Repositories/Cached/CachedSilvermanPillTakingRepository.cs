using Microsoft.Extensions.Caching.Distributed;
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
        private const string AllKey = "SilvermanPillTakings:all";
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        public async Task<List<SilvermanPillTaking>> GetAllSilvermanPillTakingsAsync()
        {
            var cached = await cache.GetStringAsync(AllKey);
            if (cached is not null)
                return JsonSerializer.Deserialize<List<SilvermanPillTaking>>(cached)!;

            var result = await inner.GetAllSilvermanPillTakingsAsync();
            await cache.SetStringAsync(AllKey, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<SilvermanPillTaking> GetSilvermanPillTakingByIdAsync(int id)
            => inner.GetSilvermanPillTakingByIdAsync(id);

        public async Task<SilvermanPillTaking> AddSilvermanPillTakingAsync(SilvermanPillTaking silvermanPillTaking)
        {
            var result = await inner.AddSilvermanPillTakingAsync(silvermanPillTaking);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task<SilvermanPillTaking> UpdateSilvermanPillTakingAsync(SilvermanPillTaking silvermanPillTaking)
        {
            var result = await inner.UpdateSilvermanPillTakingAsync(silvermanPillTaking);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task DeleteSilvermanPillTakingAsync(int id)
        {
            await inner.DeleteSilvermanPillTakingAsync(id);
            await cache.RemoveAsync(AllKey);
        }
    }
}
