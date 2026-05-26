using Microsoft.Extensions.Caching.Distributed;
using organumator.Interfaces;
using organumator.Models;
using organumator.Repositories;
using System.Text.Json;

namespace organumator.Repositories.Cached
{
    public class CachedAroundBrushingRepository(
        AroundBrushingRepository inner,
        IDistributedCache cache) : IAroundBrushingRepository
    {
        private const string AllKey = "AroundBrushings:all";
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        public async Task<List<AroundBrushing>> GetAllAroundBrushingsAsync()
        {
            var cached = await cache.GetStringAsync(AllKey);
            if (cached is not null)
                return JsonSerializer.Deserialize<List<AroundBrushing>>(cached)!;

            var result = await inner.GetAllAroundBrushingsAsync();
            await cache.SetStringAsync(AllKey, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<AroundBrushing> GetAroundBrushingByIdAsync(int id)
            => inner.GetAroundBrushingByIdAsync(id);

        public async Task<AroundBrushing> AddAroundBrushingAsync(AroundBrushing aroundBrushing)
        {
            var result = await inner.AddAroundBrushingAsync(aroundBrushing);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task<AroundBrushing> UpdateAroundBrushingAsync(AroundBrushing aroundBrushing)
        {
            var result = await inner.UpdateAroundBrushingAsync(aroundBrushing);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task DeleteAroundBrushingAsync(int id)
        {
            await inner.DeleteAroundBrushingAsync(id);
            await cache.RemoveAsync(AllKey);
        }
    }
}
