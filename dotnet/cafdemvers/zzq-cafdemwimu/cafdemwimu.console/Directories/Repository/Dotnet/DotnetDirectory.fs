namespace cafdemwimu.console.Directories.Repository.Dotnet

open System.IO
open cafdemwimu.console.Directories.Repository

type DotnetDirectory(repositoryDirectory: RepositoryDirectory) =
    member _.GetPath() =
        let repositoryDirectoryPath = repositoryDirectory.GetPath()
        Path.Combine(repositoryDirectoryPath, "dotnet")
