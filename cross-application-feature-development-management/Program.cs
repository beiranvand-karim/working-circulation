using cross_application_feature_development_management.Combiners.Classes;
using cross_application_feature_development_management.Combiners.Interfaces;
using cross_application_feature_development_management.Directories;
using cross_application_feature_development_management.Directories.Classes;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;
using cross_application_feature_development_management.Directories.Feature.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Files.Executables;
using cross_application_feature_development_management.Files.Interfaces;
using cross_application_feature_development_management.Helpers.Classes;
using cross_application_feature_development_management.Helpers.Interfaces;
using cross_application_feature_development_management.Interfaces;
using cross_application_feature_development_management.Names.Classses;
using cross_application_feature_development_management.Names.Interfaces;
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
                    services.AddTransient<ICrossApplicationFeatureDevelopmentManagement, CrossApplicationFeatureDevelopmentManagement>();
                    services.AddTransient<ICommandLineArgs, CommandLineArgs>();
                    services.AddTransient<IScriptsDirectory, ScriptsDirectory>();
                    services.AddTransient<ITemplatesDirectory, TemplatesDirectory>();
                    services.AddTransient<IHostingDirectory, HostingDirectory>();
                    services.AddTransient<IFeatureNameDirectory, FeatureNameDirectory>();
                    services.AddTransient<IEnvironmentVariablesFilesDirectory, EnvironmentVariablesFilesDirectory>();
                    services.AddTransient<ITargetDirectory, TargetDirectory>();
                    services.AddTransient<IWorkingCirculationDirectory, WorkingCirculationDirectory>();
                    services.AddTransient<IEnvironmentVariablesSourceDirectory, EnvironmentVariablesSourceDirectory>();
                    services.AddTransient<ISomethingFeatureNameDirectory, SomethingFeatureNameDirectory>();
                    services.AddTransient<IDirectoriesNameToKeyMap, DirectoriesNameToKeyMap>();
                    services.AddTransient<IPowerShellScriptsDirectory, PowerShellScriptsDirectory>();
                    services.AddTransient<IBatchScriptsDirectory, BatchScriptsDirectory>();
                    services.AddTransient<IHostApplicationName, HostApplicationName>();
                    services.AddTransient<IGuestApplicationName, GuestApplicationName>();
                    services.AddTransient<ISomething, Something>();
                    services.AddTransient<IAddToStartupScript, AddToStartupScript>();
                    services.AddTransient<IStringHelpers, StringHelpers>();
                    services.AddTransient<IDirectories, Directories.Classes.Directories>();
                    services.AddTransient<IFeatureName, FeatureName>();
                    services.AddTransient<INotePadPlusPlusOpenAll, NotePadPlusPlusOpenAll>();
                    services.AddTransient<IEnvironmentVariablesSourceFilesDirectory, EnvironmentVariablesSourceFilesDirectory>();
                    services.AddTransient<IAutomationsDirectory, AutomationsDirectory>();
                    services.AddTransient<INotePadPlusPlusAllClose, NotePadPlusPlusAllClose>();
                    services.AddTransient<INotepadPlusPlusMultitudeAllOrderReverseActionOpen, NotepadPlusPlusMultitudeAllOrderReverseActionOpen>();
                    services.AddTransient<IFrontEndDirectory, FrontEndDirectory>();
                    services.AddTransient<IFrontEndHostDirectory, FrontEndHostDirectory>();
                    services.AddTransient<IFrontEndGuestDirectory, FrontEndGuestDirectory>();
                    services.AddTransient<INotepadPlusPlusFileManagementCommandSwitcher, NotepadPlusPlusFileManagementCommandSwitcher>();
                    services.AddTransient<IProcessManager, ProcessManager>();
                    services.AddTransient<INotePadPlusPlus, NotePadPlusPlus>();
                    services.AddTransient<IDirectoryOperations, DirectoryOperations>();
                    services.AddTransient<INotesAndMessagesDirectory, NotesAndMessagesDirectory>();
                    services.AddTransient<IProcessesMetaDataDirectory, ProcessesMetaDataDirectory>();
                    services.AddTransient<ICloseProcessManagement, CloseProcessManagement>();

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