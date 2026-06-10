namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.Commands

open System.IO

type RunPrimayApplication(commandsDirectory: CommandsDirectory) =
    member _.GetPath() =
        let commandsDirectoryPath = commandsDirectory.GetPath()
        let operationsDirectory = Path.Combine(commandsDirectoryPath, "run-primary-application.ps1")
        operationsDirectory
