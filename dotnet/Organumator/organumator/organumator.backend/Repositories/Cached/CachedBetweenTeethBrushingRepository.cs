using Microsoft.Extensions.Caching.Distributed;
using organumator.Dtos;
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
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        private static string PageKey(int pageNumber, int pageSize) =>
            $"BetweenTeethBrushings:page:{pageNumber}:size:{pageSize}";

        public async Task<PagedResult<BetweenTeethBrushing>> GetAllBetweenTeethBrushingPagedAsync(int pageNumber, int pageSize)
        {
            var key = PageKey(pageNumber, pageSize);
            var cached = await cache.GetStringAsync(key);
            if (cached is not null)
                return JsonSerializer.Deserialize<PagedResult<BetweenTeethBrushing>>(cached)!;

            var result = await inner.GetAllBetweenTeethBrushingPagedAsync(pageNumber, pageSize);
            await cache.SetStringAsync(key, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<BetweenTeethBrushing> GetBetweenTeethBrushingByIdAsync(int id)
            => inner.GetBetweenTeethBrushingByIdAsync(id);

        public async Task<BetweenTeethBrushing> AddBetweenTeethBrushingAsync(BetweenTeethBrushing betweenTeethBrushing)
        {
            var result = await inner.AddBetweenTeethBrushingAsync(betweenTeethBrushing);
            await InvalidatePageCachesAsync();
            return result;
        }

        public async Task UpdateBetweenTeethBrushingAsync(BetweenTeethBrushing betweenTeethBrushing)
        {
            await inner.UpdateBetweenTeethBrushingAsync(betweenTeethBrushing);
            await InvalidatePageCachesAsync();
        }

        public async Task DeleteBetweenTeethBrushingAsync(int id)
        {
            await inner.DeleteBetweenTeethBrushingAsync(id);
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
