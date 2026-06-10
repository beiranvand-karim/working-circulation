namespace cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts

open System.IO
open cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa

type ScriptsDirectory(cafdemalihapaDirectory: CafdemalihapaDirectory) =
    member _.GetPath() =
        let cafdemalihapaDirectoryPath = cafdemalihapaDirectory.GetPath()
        let scriptsDirectoryPath = Path.Combine(cafdemalihapaDirectoryPath, "scripts")
        scriptsDirectoryPath
