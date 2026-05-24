using cafdemalihapa.Applications;
using cafdemalihapa.Applications.Cafdem;
using cafdemalihapa.Applications.DirectoryManagement;
using cafdemalihapa.Applications.NotepadPlusPlusFileManagement;
using cafdemalihapa.Applications.IdeManagement;
using cafdemalihapa.Directories;
using cafdemalihapa.Directories.Applications;
using cafdemalihapa.Directories.HostingDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.OperationsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.ProcessesMetaDataDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.BackEnd;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.BackEnd.BackEndPrimaryDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.BackEnd.BackEndSecondaryDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.Calls;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.DataDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndGuestDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndHostDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.NotesAndMessages;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.Tools;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.WebLinks;
using cafdemalihapa.Directories.Repository;
using cafdemalihapa.Directories.Repository.Cafdem;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts.AloneDirectory;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.CodeBases;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.Files.Jsons;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesTemplatesDirectory;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts.PowerShellScriptsDirectory;
using cafdemalihapa.Files.Executables;
using cafdemalihapa.Helpers;
using cafdemalihapa.Names;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace cafdemalihapa
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
                    services.AddTransient<Cafdemalihapa>();
                    services.AddTransient<CommandLineArgs>();
                    services.AddTransient<ScriptsDirectory>();
                    services.AddTransient<EnvironmentVariablesTemplatesDirectory>();
                    services.AddTransient<HostingDirectory>();
                    services.AddTransient<FeatureDirectory>();
                    services.AddTransient<EnvironmentVariablesFilesDirectory>();
                    services.AddTransient<WorkingCirculationDirectory>();
                    services.AddTransient<EnvironmentVariablesSourceDirectory>();
                    services.AddTransient<PowerShellScriptsDirectory>();
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
                    services.AddTransient<NotePadPlusPlus>();
                    services.AddTransient<DirectoryOperations>();
                    services.AddTransient<NotesAndMessagesDirectory>();
                    services.AddTransient<ProcessesMetaDataDirectory>();
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
                    services.AddTransient<CafdemalihapaCapturement>();
                    services.AddTransient<NotepadPlusPlusFileManagementCommandSwitcher>();
                    services.AddTransient<ProcessManager>();
                    services.AddTransient<CloseProcessManagement>();
                    services.AddSingleton<ToolsDirectory>();
                    services.AddSingleton<CallsDirectory>();
                    services.AddSingleton<WebLinksDirectory>();
                    services.AddSingleton<DataDirectory>();
                    services.AddSingleton<BackEndDirectory>();
                    services.AddSingleton<BackEndPrimaryDirectory>();
                    services.AddSingleton<BackEndSecondaryDirectory>();
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