namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.Commands

open System.IO

type RunSecondaryApplication(commandsDirectory: CommandsDirectory) =
    member _.GetPath() =
        let commandsDirectoryPath = commandsDirectory.GetPath()
        let operationsDirectory = Path.Combine(commandsDirectoryPath, "run-secondary-application.ps1")
        operationsDirectory
