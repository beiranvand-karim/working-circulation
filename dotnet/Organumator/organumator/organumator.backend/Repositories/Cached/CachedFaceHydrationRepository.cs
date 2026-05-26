using Microsoft.Extensions.Caching.Distributed;
using organumator.Interfaces;
using organumator.Models;
using organumator.Repositories;
using System.Text.Json;

namespace organumator.Repositories.Cached
{
    public class CachedFaceHydrationRepository(
        FaceHydrationRepository inner,
        IDistributedCache cache) : IFaceHydrationRepository
    {
        private const string AllKey = "FaceHydrations:all";
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
        };

        public async Task<List<FaceHydration>> GetAllFaceHydrationsAsync()
        {
            var cached = await cache.GetStringAsync(AllKey);
            if (cached is not null)
                return JsonSerializer.Deserialize<List<FaceHydration>>(cached)!;

            var result = await inner.GetAllFaceHydrationsAsync();
            await cache.SetStringAsync(AllKey, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<FaceHydration> GetFaceHydrationByIdAsync(int id)
            => inner.GetFaceHydrationByIdAsync(id);

        public async Task<FaceHydration> AddFaceHydrationAsync(FaceHydration faceHydration)
        {
            var result = await inner.AddFaceHydrationAsync(faceHydration);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task<FaceHydration> UpdateFaceHydrationAsync(FaceHydration faceHydration)
        {
            var result = await inner.UpdateFaceHydrationAsync(faceHydration);
            await cache.RemoveAsync(AllKey);
            return result;
        }

        public async Task DeleteFaceHydrationAsync(int id)
        {
            await inner.DeleteFaceHydrationAsync(id);
            await cache.RemoveAsync(AllKey);
        }
    }
}
