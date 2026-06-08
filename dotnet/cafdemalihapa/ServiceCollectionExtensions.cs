using cafdemalihapa.Applications;
using cafdemalihapa.Applications.Cafdemalihapa;
using cafdemalihapa.Applications.DirectoryManagement;
using cafdemalihapa.Applications.DirectoryManagement.DirectoryOpenStrategies;
using cafdemalihapa.Applications.IdeManagement;
using cafdemalihapa.Applications.NotepadPlusPlusFileManagement;
using cafdemalihapa.Directories;
using cafdemalihapa.Directories.Applications;
using cafdemalihapa.Directories.Hosting;
using cafdemalihapa.Directories.Hosting.Feature;
using cafdemalihapa.Directories.Hosting.Feature.Automations;
using cafdemalihapa.Directories.Hosting.Feature.Automations.Commands;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.DirectoriesMultitude;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.IdeJetbrains;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.Notepad;
using cafdemalihapa.Directories.Hosting.Feature.Automations.Operations;
using cafdemalihapa.Directories.Hosting.Feature.Automations.ProcessesMetaData;
using cafdemalihapa.Directories.Hosting.Feature.BackEnd;
using cafdemalihapa.Directories.Hosting.Feature.BackEnd.BackEndPrimary;
using cafdemalihapa.Directories.Hosting.Feature.BackEnd.BackEndSecondary;
using cafdemalihapa.Directories.Hosting.Feature.Calls;
using cafdemalihapa.Directories.Hosting.Feature.Data;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndGuest;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndHost;
using cafdemalihapa.Directories.Hosting.Feature.NotesAndMessages;
using cafdemalihapa.Directories.Hosting.Feature.Tools;
using cafdemalihapa.Directories.Hosting.Feature.WebLinks;
using cafdemalihapa.Directories.Repository;
using cafdemalihapa.Directories.Repository.Dotnet;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.Alone;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.CodeBases;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.Files.Jsons;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesTemplates;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.PowerShellScripts;
using cafdemalihapa.Files.Executables;
using cafdemalihapa.Helpers;
using cafdemalihapa.Names;
using Microsoft.Extensions.DependencyInjection;

namespace cafdemalihapa
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddServices(this IServiceCollection services)
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
            services.AddTransient<NotepadPlusPlusOpenAll>();
            services.AddTransient<EnvironmentVariablesSourceFilesDirectory>();
            services.AddTransient<AutomationsDirectory>();
            services.AddTransient<NotepadPlusPlusAllClose>();
            services.AddTransient<NotepadPlusPlusMultitudeAllOrderReverseActionOpen>();
            services.AddTransient<FrontEndDirectory>();
            services.AddTransient<FrontEndHostDirectory>();
            services.AddTransient<FrontEndGuestDirectory>();
            services.AddTransient<NotepadPlusPlus>();
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
            services.AddTransient<AloneDirectory>();
            services.AddTransient<CommandsDirectory>();
            services.AddTransient<PersistentVariablesFile>();
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
            services.AddSingleton<CafdemalihapaDirectory>();
            services.AddSingleton<DotnetDirectory>();
            services.AddSingleton<RepositoryDirectory>();
            services.AddSingleton<MutantVariablesFile>();
            services.AddSingleton<DirectoryManagement>();
            services.AddSingleton<Creation>();
            services.AddSingleton<Opening>();
            services.AddSingleton<IDirectoryOpenStrategy, MacDirectoryOpenStrategy>();
            services.AddSingleton<IDirectoryOpenStrategy, WindowsDirectoryOpenStrategy>();
            services.AddSingleton<IDirectoryOpenStrategy, LinuxDirectoryOpenStrategy>();
            services.AddSingleton<Shutting>();
            services.AddSingleton<FolderViewConfigurator>();
            services.AddSingleton<CodeBaseDirectory>();
            services.AddSingleton<CodeBase>();
            services.AddSingleton<DirectoryToBeOpen>();

            services.AddMultitudeServices();

            return services;
        }
    }
}
