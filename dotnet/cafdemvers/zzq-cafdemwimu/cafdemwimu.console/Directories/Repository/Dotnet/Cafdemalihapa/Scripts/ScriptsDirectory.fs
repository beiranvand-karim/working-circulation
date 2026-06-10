namespace cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts

open System.IO
open cafdemwimu.console.Directories

type ScriptsDirectory(workingDirectory: WorkingDirectory) =
    member _.GetPath() =
        let workingDirectoryPath = workingDirectory.GetPath()
        let scriptsDirectoryPath = Path.Combine(workingDirectoryPath, "scripts")
        scriptsDirectoryPath
