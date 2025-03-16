using cross_application_feature_development_management.Applications.IdeManagement;
using cross_application_feature_development_management.Combiners;
using cross_application_feature_development_management.Directories;
using cross_application_feature_development_management.Directories.Applications;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.OperationsDirectory;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Files.Executables;
using cross_application_feature_development_management.Helpers;
using cross_application_feature_development_management.Names;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace cross_application_feature_development_management
{
    internal abstract class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<CrossApplicationFeatureDevelopmentManagement>();
                    services.AddTransient<CommandLineArgs>();
                    services.AddTransient<ScriptsDirectory>();
                    services.AddTransient<TemplatesDirectory>();
                    services.AddTransient<HostingDirectory>();
                    services.AddTransient<FeatureNameDirectory>();
                    services.AddTransient<EnvironmentVariablesFilesDirectory>();
                    services.AddTransient<TargetDirectory>();
                    services.AddTransient<WorkingCirculationDirectory>();
                    services.AddTransient<EnvironmentVariablesSourceDirectory>();
                    services.AddTransient<SomethingFeatureNameDirectory>();
                    services.AddTransient<DirectoriesNameToKeyMap>();
                    services.AddTransient<PowerShellScriptsDirectory>();
                    services.AddTransient<BatchScriptsDirectory>();
                    services.AddTransient<HostApplicationName>();
                    services.AddTransient<GuestApplicationName>();
                    services.AddTransient<Something>();
                    services.AddTransient<AddToStartupScript>();
                    services.AddTransient<StringHelpers>();
                    services.AddTransient<Directories.Directories>();
                    services.AddTransient<FeatureName>();
                    services.AddTransient<NotePadPlusPlusOpenAll>();
                    services.AddTransient<EnvironmentVariablesSourceFilesDirectory>();
                    services.AddTransient<AutomationsDirectory>();
                    services.AddTransient<NotePadPlusPlusAllClose>();
                    services.AddTransient<NotepadPlusPlusMultitudeAllOrderReverseActionOpen>();
                    services.AddTransient<FrontEndDirectory>();
                    services.AddTransient<FrontEndHostDirectory>();
                    services.AddTransient<FrontEndGuestDirectory>();
                    services.AddTransient<NotepadPlusPlusFileManagementCommandSwitcher>();
                    services.AddTransient<ProcessManager>();
                    services.AddTransient<NotePadPlusPlus>();
                    services.AddTransient<DirectoryOperations>();
                    services.AddTransient<NotesAndMessagesDirectory>();
                    services.AddTransient<ProcessesMetaDataDirectory>();
                    services.AddTransient<CloseProcessManagement>();
                    services.AddTransient<OperationsDirectory>();
                    services.AddTransient<IdeProcessManagement>();
                    services.AddTransient<IdeManagement>();
                    services.AddTransient<ApplicationLocation>();
                    services.AddTransient<IdeExecutiveFileLocation>();
                    services.AddTransient<ApplicationName>();
                    services.AddTransient<IdeName>();
                    services.AddTransient<IdeJetbrainsRiderMultitudePrimaryActionOpen>();
                    services.AddTransient<IdeJetbrainsRiderMultitudeSecondaryActionOpen>();
                    services.AddTransient<IdeJetbrainsWebstormMultitudePrimaryActionOpen>();
                    services.AddTransient<IdeJetbrainsWebstormMultitudeSecondaryActionOpen>();
                    services.AddTransient<IdeJetbrainsWebstormMultitudePrimaryActionShut>();
                    services.AddTransient<IdeJetbrainsWebstormMultitudeSecondaryActionShut>();
                    services.AddTransient<IdeJetbrainsRiderMultitudePrimaryActionShut>();
                    services.AddTransient<IdeJetbrainsRiderMultitudeSecondaryActionShut>();
                    services.AddTransient<AloneDirectory>();
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<CrossApplicationFeatureDevelopmentManagementCommandSwitcher>(host.Services);
            svc.Run();
        }

        private static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}