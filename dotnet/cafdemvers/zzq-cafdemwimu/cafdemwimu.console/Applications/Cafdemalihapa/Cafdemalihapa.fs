namespace cafdemwimu.console.Applications.Cafdemalihapa

open Microsoft.Extensions.Logging
open cafdemwimu.console.Directories.Hosting.Feature
open cafdemwimu.console.Directories.Hosting.Feature.Automations
open cafdemwimu.console.Directories.Hosting.Feature.Automations.Commands
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles
open cafdemwimu.console.Directories.Hosting.Feature.Automations.Operations
open cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.PowerShellScripts

type Cafdemalihapa
    (
        logger: ILogger<Cafdemalihapa>,
        environmentVariablesFilesDirectory: EnvironmentVariablesFilesDirectory,
        powerShellScriptsDirectory: PowerShellScriptsDirectory,
        environmentVariablesSourceFilesDirectory: EnvironmentVariablesSourceFilesDirectory,
        automationsDirectory: AutomationsDirectory,
        operationsDirectory: OperationsDirectory,
        commandsDirectory: CommandsDirectory,
        folderViewConfigurator: FolderViewConfigurator
    ) =
    member this.Run() =
        try
            this.CreateDirectories()

            environmentVariablesSourceFilesDirectory.Populate()

            powerShellScriptsDirectory.CopyContentToDirectory()
            commandsDirectory.ReplaceFileNamesWithPaths()

            operationsDirectory.ReplaceFileNamesWithPaths()

            folderViewConfigurator.Configure()
        with ex ->
            logger.LogInformation("Cafdemalihapa: An error occurred while running the application.")
            logger.LogInformation("_________________________________________________")
            logger.LogError(ex, "Cafdemalihapa: An unhandled error occurred while running the application.")
            logger.LogInformation("_________________________________________________")

    member _.CreateDirectories() =
        FeatureDirectory.Create()
        automationsDirectory.Create()
        environmentVariablesFilesDirectory.Create()
        commandsDirectory.Create()
        operationsDirectory.Create()
