namespace cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource

open System.IO
open cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts

type EnvironmentVariablesSourceDirectory(scriptsDirectory: ScriptsDirectory) =
    member _.GetPath() =
        let environmentVariablesSourceDirectory =
            Path.Combine(scriptsDirectory.GetPath(), "environment-variables-source")
        environmentVariablesSourceDirectory
