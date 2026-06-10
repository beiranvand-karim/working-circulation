namespace cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa

open System.IO
open cafdemwimu.console.Directories.Repository.Dotnet

type CafdemalihapaDirectory(dotnetDirectory: DotnetDirectory) =
    member _.GetPath() =
        let dotnetDirectoryPath = dotnetDirectory.GetPath()
        let cafdemalihapaDirectoryPath = Path.Combine(dotnetDirectoryPath, "cafdemalihapa")
        cafdemalihapaDirectoryPath
