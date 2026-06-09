using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.DirectoriesMultitude;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.IdeJetbrains;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.IdeMicrosoft;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.Notepad;
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
            services.AddTransient<IdeMicrosoftVscodeDefaultMultitudePrimaryActionOpen>();
            services.AddTransient<IdeMicrosoftVscodeDefaultMultitudeSecondaryActionOpen>();
            services.AddTransient<IdeMicrosoftVscodeDefaultMultitudePrimaryActionShut>();
            services.AddTransient<IdeMicrosoftVscodeDefaultMultitudeSecondaryActionShut>();
            services.AddTransient<IdeMicrosoftVscodeInsidersMultitudePrimaryActionOpen>();
            services.AddTransient<IdeMicrosoftVscodeInsidersMultitudeSecondaryActionOpen>();
            services.AddTransient<IdeMicrosoftVscodeInsidersMultitudePrimaryActionShut>();
            services.AddTransient<IdeMicrosoftVscodeInsidersMultitudeSecondaryActionShut>();

            return services;
        }
    }
}
