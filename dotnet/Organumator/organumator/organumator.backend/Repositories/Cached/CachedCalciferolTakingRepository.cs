using Microsoft.Extensions.Caching.Distributed;
using organumator.Interfaces;
using organumator.Repositories;
using System.Text.Json;

namespace organumator.Repositories.Cached
{
    public class CachedCalciferolTakingRepository(
        CalciferolTakingRepository inner,
        IDistributedCache cache) : ICalciferolTakingRepository
    {
        private const string AllKey = "CalciferolTakings:all";
        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        public async Task<IEnumerable<Models.CalciferolTakingModel>> GetAllAsync()
        {
            var cached = await cache.GetStringAsync(AllKey);
            if (cached is not null)
                return JsonSerializer.Deserialize<List<Models.CalciferolTakingModel>>(cached)!;

            var result = await inner.GetAllAsync();
            await cache.SetStringAsync(AllKey, JsonSerializer.Serialize(result), CacheOptions);
            return result;
        }

        public Task<Models.CalciferolTakingModel> GetByIdAsync(int id)
            => inner.GetByIdAsync(id);

        public async Task AddAsync(Models.CalciferolTakingModel calciferolTakingModel)
        {
            await inner.AddAsync(calciferolTakingModel);
            await cache.RemoveAsync(AllKey);
        }

        public async Task UpdateAsync(Models.CalciferolTakingModel calciferolTakingModel)
        {
            await inner.UpdateAsync(calciferolTakingModel);
            await cache.RemoveAsync(AllKey);
        }

        public async Task DeleteAsync(int id)
        {
            await inner.DeleteAsync(id);
            await cache.RemoveAsync(AllKey);
        }
    }
}
