using Microsoft.Extensions.Caching.Distributed;
using organumator.Dtos;
using organumator.Interfaces;
using organumator.Models;
using organumator.Repositories;
using System.Text.Json;

namespace organumator.Repositories.Cached
{
    public class CachedClothesWearingRepository(
        ClothesWearingRepository inner,
        IDistributedCache cache) : IClothesWearingRepository
    {
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        private static string PageKey(int pageNumber, int pageSize) =>
            $"ClothesWearings:page:{pageNumber}:size:{pageSize}";

        public async Task<PagedResult<ClothesWearing>> GetAllClothesWearingsPagedAsync(int pageNumber, int pageSize)
        {
            var key = PageKey(pageNumber, pageSize);
            var cached = await cache.GetStringAsync(key);
            if (cached is not null)
                return JsonSerializer.Deserialize<PagedResult<ClothesWearing>>(cached)!;

            var result = await inner.GetAllClothesWearingsPagedAsync(pageNumber, pageSize);
            await cache.SetStringAsync(key, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<ClothesWearing> GetClothesWearingByIdAsync(int id)
            => inner.GetClothesWearingByIdAsync(id);

        public async Task<ClothesWearing> AddClothesWearingAsync(ClothesWearing clothesWearing)
        {
            var result = await inner.AddClothesWearingAsync(clothesWearing);
            await InvalidatePageCachesAsync();
            return result;
        }

        public async Task<ClothesWearing> UpdateClothesWearingAsync(ClothesWearing clothesWearing)
        {
            var result = await inner.UpdateClothesWearingAsync(clothesWearing);
            await InvalidatePageCachesAsync();
            return result;
        }

        public async Task DeleteClothesWearingAsync(int id)
        {
            await inner.DeleteClothesWearingAsync(id);
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
