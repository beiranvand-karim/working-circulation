namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.Commands

open System.IO

type RunTertiaryApplication(commandsDirectory: CommandsDirectory) =
    member _.GetPath() =
        let commandsDirectoryPath = commandsDirectory.GetPath()
        let operationsDirectory = Path.Combine(commandsDirectoryPath, "run-tertiary-application.ps1")
        operationsDirectory
