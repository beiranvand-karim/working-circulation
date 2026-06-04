using Microsoft.Extensions.Caching.Distributed;
using organumator.Dtos;
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
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
        };

        private static string PageKey(int pageNumber, int pageSize) =>
            $"FaceHydrations:page:{pageNumber}:size:{pageSize}";

        public async Task<PagedResult<FaceHydration>> GetAllFaceHydrationsPagedAsync(int pageNumber, int pageSize)
        {
            var key = PageKey(pageNumber, pageSize);
            var cached = await cache.GetStringAsync(key);
            if (cached is not null)
                return JsonSerializer.Deserialize<PagedResult<FaceHydration>>(cached)!;

            var result = await inner.GetAllFaceHydrationsPagedAsync(pageNumber, pageSize);
            await cache.SetStringAsync(key, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<FaceHydration> GetFaceHydrationByIdAsync(int id)
            => inner.GetFaceHydrationByIdAsync(id);

        public async Task<FaceHydration> AddFaceHydrationAsync(FaceHydration faceHydration)
        {
            var result = await inner.AddFaceHydrationAsync(faceHydration);
            await InvalidatePageCachesAsync(result.Id);
            return result;
        }

        public async Task<FaceHydration> UpdateFaceHydrationAsync(FaceHydration faceHydration)
        {
            var result = await inner.UpdateFaceHydrationAsync(faceHydration);
            await InvalidatePageCachesAsync();
            return result;
        }

        public async Task DeleteFaceHydrationAsync(int id)
        {
            await inner.DeleteFaceHydrationAsync(id);
            await InvalidatePageCachesAsync();
        }

        // Clears the first 20 pages for common page sizes on any mutation.
        // Pages beyond that will naturally expire within 5 minutes.
        private async Task InvalidatePageCachesAsync(int? _ = null)
        {
            int[] commonPageSizes = [5, 10, 20, 25, 50];
            var removals = new List<Task>();
            foreach (var size in commonPageSizes)
                for (var page = 1; page <= 20; page++)
                    removals.Add(cache.RemoveAsync(PageKey(page, size)));
            await Task.WhenAll(removals);
        }
    }
}
