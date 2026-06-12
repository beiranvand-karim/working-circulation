namespace cafdemwimu.console

open System.Runtime.CompilerServices
open Microsoft.Extensions.DependencyInjection
open cafdemwimu.console
open cafdemwimu.console.Applications
open cafdemwimu.console.Applications.Cafdemalihapa
open cafdemwimu.console.Applications.DirectoryManagement
open cafdemwimu.console.Applications.DirectoryManagement.DirectoryOpenStrategies
open cafdemwimu.console.Applications.IdeManagement
open cafdemwimu.console.Applications.NotepadPlusPlusFileManagement
open cafdemwimu.console.Directories
open cafdemwimu.console.Directories.Applications
open cafdemwimu.console.Directories.Hosting.Feature
open cafdemwimu.console.Directories.Hosting.Feature.Automations
open cafdemwimu.console.Directories.Hosting.Feature.Automations.Commands
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.DirectoriesMultitude
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.Notepad
open cafdemwimu.console.Directories.Hosting.Feature.Automations.Operations
open cafdemwimu.console.Directories.Hosting.Feature.Automations.ProcessesMetaData
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndPrimary
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndSecondary
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndTertiary
open cafdemwimu.console.Directories.Hosting.Feature.Calls
open cafdemwimu.console.Directories.Hosting.Feature.Data
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndPrimary
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndSecondary
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndTertiary
open cafdemwimu.console.Directories.Hosting.Feature.NotesAndMessages
open cafdemwimu.console.Directories.Hosting.Feature.Tools
open cafdemwimu.console.Directories.Hosting.Feature.WebLinks
open cafdemwimu.console.Directories.Repository
open cafdemwimu.console.Directories.Repository.Dotnet
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.Alone
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource.CodeBases
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource.Files.Jsons
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesTemplates
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.PowerShellScripts
open cafdemwimu.console.Files.Executables
open cafdemwimu.console.Helpers
open cafdemwimu.console.Names

[<Extension>]
type ServiceCollectionExtensions =
    [<Extension>]
    static member AddServices(services: IServiceCollection) : IServiceCollection =
        services.AddTransient<Cafdemalihapa>() |> ignore
        services.AddTransient<CommandLineArgs>() |> ignore
        services.AddTransient<ScriptsDirectory>() |> ignore
        services.AddTransient<EnvironmentVariablesTemplatesDirectory>() |> ignore
        services.AddTransient<EnvironmentVariablesFilesDirectory>() |> ignore
        services.AddTransient<WorkingCirculationDirectory>() |> ignore
        services.AddTransient<EnvironmentVariablesSourceDirectory>() |> ignore
        services.AddTransient<PowerShellScriptsDirectory>() |> ignore
        services.AddTransient<PrimaryApplication>() |> ignore
        services.AddTransient<SecondaryApplication>() |> ignore
        services.AddTransient<TertiaryApplication>() |> ignore
        services.AddTransient<Something>() |> ignore
        services.AddTransient<DirectoriesMultitudeStartupActionOpen>() |> ignore
        services.AddTransient<StringHelpers>() |> ignore
        services.AddTransient<FeatureName>() |> ignore
        services.AddTransient<NotepadPlusPlusOpenAll>() |> ignore
        services.AddTransient<EnvironmentVariablesSourceFilesDirectory>() |> ignore
        services.AddTransient<AutomationsDirectory>() |> ignore
        services.AddTransient<NotepadPlusPlusAllClose>() |> ignore
        services.AddTransient<NotepadPlusPlusMultitudeAllOrderReverseActionOpen>() |> ignore
        services.AddTransient<FrontEndDirectory>() |> ignore
        services.AddTransient<FrontEndPrimaryDirectory>() |> ignore
        services.AddTransient<FrontEndSecondaryDirectory>() |> ignore
        services.AddTransient<FrontEndTertiaryDirectory>() |> ignore
        services.AddTransient<NotepadPlusPlus>() |> ignore
        services.AddTransient<DirectoryOperations>() |> ignore
        services.AddTransient<NotesAndMessagesDirectory>() |> ignore
        services.AddTransient<ProcessesMetaDataDirectory>() |> ignore
        services.AddTransient<OperationsDirectory>() |> ignore
        services.AddTransient<IdeProcessManagement>() |> ignore
        services.AddTransient<IdeManagement>() |> ignore
        services.AddTransient<ApplicationLocation>() |> ignore
        services.AddTransient<IdeExecutiveFileLocation>() |> ignore
        services.AddTransient<ApplicationName>() |> ignore
        services.AddTransient<IdeName>() |> ignore
        services.AddTransient<AloneDirectory>() |> ignore
        services.AddTransient<CommandsDirectory>() |> ignore
        services.AddTransient<PersistentVariablesFile>() |> ignore
        services.AddTransient<NotepadPlusPlusFileManagementCommandSwitcher>() |> ignore
        services.AddTransient<ProcessManager>() |> ignore
        services.AddTransient<CloseProcessManagement>() |> ignore
        services.AddSingleton<ToolsDirectory>() |> ignore
        services.AddSingleton<CallsDirectory>() |> ignore
        services.AddSingleton<WebLinksDirectory>() |> ignore
        services.AddSingleton<DataDirectory>() |> ignore
        services.AddSingleton<BackEndPrimaryDirectory>() |> ignore
        services.AddSingleton<BackEndSecondaryDirectory>() |> ignore
        services.AddSingleton<BackEndTertiaryDirectory>() |> ignore
        services.AddSingleton<RepositoryDirectory>() |> ignore
        services.AddSingleton<MutantVariablesFile>() |> ignore
        services.AddSingleton<DirectoryManagement>() |> ignore
        services.AddSingleton<Creation>() |> ignore
        services.AddSingleton<Opening>() |> ignore
        services.AddSingleton<IDirectoryOpenStrategy, MacDirectoryOpenStrategy>() |> ignore
        services.AddSingleton<IDirectoryOpenStrategy, WindowsDirectoryOpenStrategy>() |> ignore
        services.AddSingleton<IDirectoryOpenStrategy, LinuxDirectoryOpenStrategy>() |> ignore
        services.AddSingleton<Shutting>() |> ignore
        services.AddSingleton<FolderViewConfigurator>() |> ignore
        services.AddSingleton<CodeBaseDirectory>() |> ignore
        services.AddSingleton<CodeBase>() |> ignore
        services.AddSingleton<DirectoryToBeOpen>() |> ignore

        services.AddMultitudeServices() |> ignore

        services
