using StackExchange.Redis;

namespace organumator.Extensions
{
    public static class CacheStartupExtensions
    {
        /// <summary>
        /// In production, caching is disabled. Clear any cache entries left behind by a
        /// previous (cached) run so production never serves stale cached data.
        /// </summary>
        public static async Task ClearProductionCacheAsync(this WebApplication app)
        {
            if (!app.Environment.IsProduction())
                return;

            var redisConnectionString = app.Configuration["Redis:ConnectionString"];
            if (string.IsNullOrWhiteSpace(redisConnectionString))
            {
                app.Logger.LogInformation("Production cache clear skipped: no Redis connection string configured.");
                return;
            }

            var instanceName = app.Configuration["Redis:InstanceName"] ?? string.Empty;
            try
            {
                await using var multiplexer = await ConnectionMultiplexer.ConnectAsync(redisConnectionString);
                var database = multiplexer.GetDatabase();
                var deleted = 0;
                foreach (var endpoint in multiplexer.GetEndPoints())
                {
                    var server = multiplexer.GetServer(endpoint);
                    foreach (var key in server.Keys(pattern: $"{instanceName}*"))
                    {
                        await database.KeyDeleteAsync(key);
                        deleted++;
                    }
                }
                app.Logger.LogInformation("Production cache cleared: removed {Count} Redis key(s) with prefix '{Prefix}'.", deleted, instanceName);
            }
            catch (Exception ex)
            {
                app.Logger.LogError(ex, "Failed to clear Redis cache on production startup.");
            }
        }
    }
}
