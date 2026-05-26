using Microsoft.Extensions.Caching.Distributed;
using organumator.Interfaces;
using organumator.Models;
using organumator.Repositories;
using System.Text.Json;

namespace organumator.Repositories.Cached
{
    public class CachedBetweenTeethBrushingRepository(
        BetweenTeethBrushingRepository inner,
        IDistributedCache cache) : IBetweenTeethBrushingRepository
    {
        private const string AllKey = "BetweenTeethBrushings:all";
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        public async Task<IEnumerable<BetweenTeethBrushing>> GetAllBetweenTeethBrushingAsync()
        {
            var cached = await cache.GetStringAsync(AllKey);
            if (cached is not null)
                return JsonSerializer.Deserialize<List<BetweenTeethBrushing>>(cached)!;

            var result = await inner.GetAllBetweenTeethBrushingAsync();
            await cache.SetStringAsync(AllKey, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<BetweenTeethBrushing> GetBetweenTeethBrushingByIdAsync(int id)
            => inner.GetBetweenTeethBrushingByIdAsync(id);

        public async Task<BetweenTeethBrushing> AddBetweenTeethBrushingAsync(BetweenTeethBrushing betweenTeethBrushing)
        {
            var result = await inner.AddBetweenTeethBrushingAsync(betweenTeethBrushing);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task UpdateBetweenTeethBrushingAsync(BetweenTeethBrushing betweenTeethBrushing)
        {
            await inner.UpdateBetweenTeethBrushingAsync(betweenTeethBrushing);
            await cache.RemoveAsync(AllKey);
        }

        public async Task DeleteBetweenTeethBrushingAsync(int id)
        {
            await inner.DeleteBetweenTeethBrushingAsync(id);
            await cache.RemoveAsync(AllKey);
        }
    }
}
