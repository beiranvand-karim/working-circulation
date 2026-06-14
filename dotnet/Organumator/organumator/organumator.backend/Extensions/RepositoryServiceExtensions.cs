using organumator.Interfaces;
using organumator.Repositories;
using organumator.Repositories.Cached;

namespace organumator.Extensions
{
    public static class RepositoryServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, bool useRedisCache)
        {
            services.AddScoped<AroundBrushingRepository>();
            services.AddScoped<FaceHydrationRepository>();
            services.AddScoped<SilvermanPillTakingRepository>();
            services.AddScoped<LivergolPillTakingRepository>();
            services.AddScoped<BetweenTeethBrushingRepository>();
            services.AddScoped<CalciferolTakingRepository>();
            services.AddScoped<VacuumCleaningsRepository>();
            services.AddScoped<ClothesWearingRepository>();

            if (useRedisCache)
            {
                services.AddScoped<IAroundBrushingRepository, CachedAroundBrushingRepository>();
                services.AddScoped<IFaceHydrationRepository, CachedFaceHydrationRepository>();
                services.AddScoped<ISilvermanPillTakingRepository, CachedSilvermanPillTakingRepository>();
                services.AddScoped<ILivergolPillTakingRepository, CachedLivergolPillTakingRepository>();
                services.AddScoped<IBetweenTeethBrushingRepository, CachedBetweenTeethBrushingRepository>();
                services.AddScoped<ICalciferolTakingRepository, CachedCalciferolTakingRepository>();
                services.AddScoped<IVacuumCleaningsRepository, CachedVacuumCleaningsRepository>();
                services.AddScoped<IClothesWearingRepository, CachedClothesWearingRepository>();
            }
            else
            {
                services.AddScoped<IAroundBrushingRepository>(sp => sp.GetRequiredService<AroundBrushingRepository>());
                services.AddScoped<IFaceHydrationRepository>(sp => sp.GetRequiredService<FaceHydrationRepository>());
                services.AddScoped<ISilvermanPillTakingRepository>(sp => sp.GetRequiredService<SilvermanPillTakingRepository>());
                services.AddScoped<ILivergolPillTakingRepository>(sp => sp.GetRequiredService<LivergolPillTakingRepository>());
                services.AddScoped<IBetweenTeethBrushingRepository>(sp => sp.GetRequiredService<BetweenTeethBrushingRepository>());
                services.AddScoped<ICalciferolTakingRepository>(sp => sp.GetRequiredService<CalciferolTakingRepository>());
                services.AddScoped<IVacuumCleaningsRepository>(sp => sp.GetRequiredService<VacuumCleaningsRepository>());
                services.AddScoped<IClothesWearingRepository>(sp => sp.GetRequiredService<ClothesWearingRepository>());
            }

            services.AddScoped<ICleanupTimeManagementRepository, CleanupTimeManagementRepository>();
            services.AddScoped<ISimcardChargingRepository, SimcardChargingRepository>();

            return services;
        }
    }
}
