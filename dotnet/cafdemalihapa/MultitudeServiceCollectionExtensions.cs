using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles;
using Microsoft.Extensions.DependencyInjection;

namespace cafdemalihapa
{
    internal static class MultitudeServiceCollectionExtensions
    {
        internal static IServiceCollection AddMultitudeServices(this IServiceCollection services)
        {
            services.AddSingleton<DirectoriesMultitudeServingOrderReverseActionOpen>();
            services.AddSingleton<DirectoriesMultitudeCommandingOrderReverseActionOpen>();
            services.AddSingleton<DirectoriesMultitudeCommandingOrderRectoActionOpen>();
            services.AddSingleton<DirectoriesMultitudeCommandingOrderRectoActionShut>();
            services.AddSingleton<DirectoriesMultitudeServingOrderRectoActionOpen>();
            services.AddSingleton<DirectoriesMultitudeServingOrderRectoActionShut>();
            services.AddTransient<IdeJetbrainsRiderMultitudePrimaryActionOpen>();
            services.AddTransient<IdeJetbrainsRiderMultitudeSecondaryActionOpen>();
            services.AddTransient<IdeJetbrainsWebstormMultitudePrimaryActionOpen>();
            services.AddTransient<IdeJetbrainsWebstormMultitudeSecondaryActionOpen>();
            services.AddTransient<IdeJetbrainsWebstormMultitudePrimaryActionShut>();
            services.AddTransient<IdeJetbrainsWebstormMultitudeSecondaryActionShut>();
            services.AddTransient<IdeJetbrainsRiderMultitudePrimaryActionShut>();
            services.AddTransient<IdeJetbrainsRiderMultitudeSecondaryActionShut>();

            return services;
        }
    }
}
