using Microsoft.Extensions.Caching.Distributed;
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
        private const string AllKey = "ClothesWearings:all";
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        public async Task<List<ClothesWearing>> GetAllClothesWearingsAsync()
        {
            var cached = await cache.GetStringAsync(AllKey);
            if (cached is not null)
                return JsonSerializer.Deserialize<List<ClothesWearing>>(cached)!;

            var result = await inner.GetAllClothesWearingsAsync();
            await cache.SetStringAsync(AllKey, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<ClothesWearing> GetClothesWearingByIdAsync(int id)
            => inner.GetClothesWearingByIdAsync(id);

        public async Task<ClothesWearing> AddClothesWearingAsync(ClothesWearing clothesWearing)
        {
            var result = await inner.AddClothesWearingAsync(clothesWearing);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task<ClothesWearing> UpdateClothesWearingAsync(ClothesWearing clothesWearing)
        {
            var result = await inner.UpdateClothesWearingAsync(clothesWearing);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task DeleteClothesWearingAsync(int id)
        {
            await inner.DeleteClothesWearingAsync(id);
            await cache.RemoveAsync(AllKey);
        }
    }
}
