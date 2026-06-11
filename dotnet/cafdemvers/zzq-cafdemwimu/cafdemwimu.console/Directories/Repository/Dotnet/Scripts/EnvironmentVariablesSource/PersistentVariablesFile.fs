namespace cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource.Files.Jsons

open System.IO
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource

type PersistentVariablesFile(environmentVariablesSourceDirectory: EnvironmentVariablesSourceDirectory) =
    member _.GetName() = "persistent-variables.json"

    member this.GetPath() =
        let name = this.GetName()
        Path.Combine(environmentVariablesSourceDirectory.GetPath(), name)
