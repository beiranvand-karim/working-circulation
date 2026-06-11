namespace cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource

open System.IO
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts

type EnvironmentVariablesSourceDirectory(scriptsDirectory: ScriptsDirectory) =
    member _.GetPath() =
        let environmentVariablesSourceDirectory =
            Path.Combine(scriptsDirectory.GetPath(), "environment-variables-source")
        environmentVariablesSourceDirectory
