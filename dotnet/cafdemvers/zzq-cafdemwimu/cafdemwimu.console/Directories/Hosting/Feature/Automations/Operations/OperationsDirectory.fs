namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.Operations

open System.IO
open cafdemwimu.console.Directories
open cafdemwimu.console.Directories.Hosting.Feature.Automations

type OperationsDirectory(automationsDirectory: AutomationsDirectory) =
    member this.Create() =
        let path = this.GetPath()
        Directory.CreateDirectory(path) |> ignore

    member _.GetPath() =
        let directory = automationsDirectory.GetPath()
        let operationsDirectory = Path.Combine(directory, "operations")
        operationsDirectory

    member this.ReplaceFileNamesWithPaths() =
        let giversPath = Path.Combine(automationsDirectory.GetPath(), "commands")
        let pathToTarget = this.GetPath()
        for filePath in Directory.EnumerateFiles(pathToTarget) do
            let fileName = Path.GetFileNameWithoutExtension(filePath)
            let giverFileName = $"{fileName}.ps1"
            let giverPath = Path.Combine(giversPath, giverFileName)
            DirectoryServices.ReplaceFileNameWithPath(filePath, giverPath)
