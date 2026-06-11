namespace cafdemwimu.console.Directories.Repository.Dotnet.Scripts.PowerShellScripts

open System.IO
open cafdemwimu.console.Directories
open cafdemwimu.console.Directories.Hosting.Feature.Automations.Commands
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts

type PowerShellScriptsDirectory(scriptsDirectory: ScriptsDirectory, commandsDirectory: CommandsDirectory) =
    let directoryNameInSourceCode = "powershell-scripts"

    member this.CopyContentToDirectory() =
        let destinationDirectory = commandsDirectory.GetPath()
        let sourceDirectory = this.GetPath()
        DirectoryServices.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory)

    member _.GetPath() =
        let scriptsDirectoryName = scriptsDirectory.GetPath()
        let powerShellDirectoryPathInSourceCode = Path.Combine(scriptsDirectoryName, directoryNameInSourceCode)
        powerShellDirectoryPathInSourceCode
