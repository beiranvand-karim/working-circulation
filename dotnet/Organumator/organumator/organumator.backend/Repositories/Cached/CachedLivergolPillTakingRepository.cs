using Microsoft.Extensions.Caching.Distributed;
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
        private const string AllKey = "LivergolPillTakings:all";
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        public async Task<List<LivergolPillTakingModel>> GetAllLivergolPillTakingsAsync()
        {
            var cached = await cache.GetStringAsync(AllKey);
            if (cached is not null)
                return JsonSerializer.Deserialize<List<LivergolPillTakingModel>>(cached)!;

            var result = await inner.GetAllLivergolPillTakingsAsync();
            await cache.SetStringAsync(AllKey, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<LivergolPillTakingModel> GetLivergolPillTakingByIdAsync(int id)
            => inner.GetLivergolPillTakingByIdAsync(id);

        public async Task<LivergolPillTakingModel> AddLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking)
        {
            var result = await inner.AddLivergolPillTakingAsync(livergolPillTaking);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task<LivergolPillTakingModel> UpdateLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking)
        {
            var result = await inner.UpdateLivergolPillTakingAsync(livergolPillTaking);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task DeleteLivergolPillTakingAsync(int id)
        {
            await inner.DeleteLivergolPillTakingAsync(id);
            await cache.RemoveAsync(AllKey);
        }
    }
}
