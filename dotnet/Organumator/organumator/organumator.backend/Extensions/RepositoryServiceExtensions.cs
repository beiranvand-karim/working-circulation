using organumator.Interfaces;
using organumator.Repositories;
using organumator.Repositories.Cached;

namespace organumator.Extensions
{
    public static class RepositoryServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<AroundBrushingRepository>();
            services.AddScoped<IAroundBrushingRepository, CachedAroundBrushingRepository>();

            services.AddScoped<FaceHydrationRepository>();
            services.AddScoped<IFaceHydrationRepository, CachedFaceHydrationRepository>();

            services.AddScoped<SilvermanPillTakingRepository>();
            services.AddScoped<ISilvermanPillTakingRepository, CachedSilvermanPillTakingRepository>();

            services.AddScoped<LivergolPillTakingRepository>();
            services.AddScoped<ILivergolPillTakingRepository, CachedLivergolPillTakingRepository>();

            services.AddScoped<BetweenTeethBrushingRepository>();
            services.AddScoped<IBetweenTeethBrushingRepository, CachedBetweenTeethBrushingRepository>();

            services.AddScoped<CalciferolTakingRepository>();
            services.AddScoped<ICalciferolTakingRepository, CachedCalciferolTakingRepository>();

            services.AddScoped<VacuumCleaningsRepository>();
            services.AddScoped<IVacuumCleaningsRepository, CachedVacuumCleaningsRepository>();

            services.AddScoped<ClothesWearingRepository>();
            services.AddScoped<IClothesWearingRepository, CachedClothesWearingRepository>();

            services.AddScoped<ICleanupTimeManagementRepository, CleanupTimeManagementRepository>();
            services.AddScoped<ISimcardChargingRepository, SimcardChargingRepository>();

            return services;
        }
    }
}
