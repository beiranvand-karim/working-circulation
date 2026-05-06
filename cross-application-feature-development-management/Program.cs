using cross_application_feature_development_management.Applications;
using cross_application_feature_development_management.Applications.Cafdem;
using cross_application_feature_development_management.Applications.DirectoryManagement;
using cross_application_feature_development_management.Applications.IdeManagement;
using cross_application_feature_development_management.Applications.NotepadPlusPlusFileManagement;
using cross_application_feature_development_management.Directories;
using cross_application_feature_development_management.Directories.Applications;
using cross_application_feature_development_management.Directories.HostingDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.OperationsDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.ProcessesMetaDataDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.BackEnd;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Calls;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.NotesAndMessages;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Tools;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.WebLinks;
using cross_application_feature_development_management.Directories.Repository;
using cross_application_feature_development_management.Directories.Repository.Cafdem;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.AloneDirectory;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.BatchScriptsDirectory;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.CodeBases;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.Files.Jsons;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesTemplatesDirectory;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.PowerShellScriptsDirectory;
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
                    services.AddTransient<EnvironmentVariablesTemplatesDirectory>();
                    services.AddTransient<HostingDirectory>();
                    services.AddTransient<FeatureDirectory>();
                    services.AddTransient<EnvironmentVariablesFilesDirectory>();
                    services.AddTransient<WorkingCirculationDirectory>();
                    services.AddTransient<EnvironmentVariablesSourceDirectory>();
                    services.AddTransient<PowerShellScriptsDirectory>();
                    services.AddTransient<BatchScriptsDirectory>();
                    services.AddTransient<PrimaryApplication>();
                    services.AddTransient<SecondaryApplication>();
                    services.AddTransient<Something>();
                    services.AddTransient<DirectoriesMultitudeStartupActionOpen>();
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
                    services.AddTransient<CommandsDirectory>();
                    services.AddTransient<PersistentVariablesFile>();
                    services.AddTransient<SeparationFilementDirectory>();
                    services.AddTransient<CafdemTerminalCapturement>();
                    services.AddSingleton<ToolsDirectory>();
                    services.AddSingleton<CallsDirectory>();
                    services.AddSingleton<WebLinksDirectory>();
                    services.AddSingleton<BackEndDirectory>();
                    services.AddSingleton<DirectoriesMultitudeServingOrderReverseActionOpen>();
                    services.AddSingleton<DirectoriesMultitudeCommandingOrderReverseActionOpen>();
                    services.AddSingleton<DirectoriesMultitudeCommandingOrderRectoActionOpen>();
                    services.AddSingleton<DirectoriesMultitudeCommandingOrderRectoActionShut>();
                    services.AddSingleton<DirectoriesMultitudeServingOrderRectoActionOpen>();
                    services.AddSingleton<DirectoriesMultitudeServingOrderRectoActionShut>();
                    services.AddSingleton<CafdemDirectory>();
                    services.AddSingleton<RepositoryDirectory>();
                    services.AddSingleton<MutantVariablesFile>();
                    services.AddSingleton<DirectoryManagement>();
                    services.AddSingleton<CodeBaseDirectory>();
                    services.AddSingleton<CodeBase>();
                    services.AddSingleton<DirectoryToBeOpen>();
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<ApplicationSwitcher>(host.Services);
            svc.Run();
        }

        private static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}