namespace cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.CodeBases

open System.IO
open cafdemwimu.console.Applications.Cafdemalihapa
open cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource

type CodeBaseDirectory(environmentVariablesSourceDirectory: EnvironmentVariablesSourceDirectory, codeBase: CodeBase) =
    member _.GetPath() =
        let codeBaseValue = codeBase.GetCodeBaseValue()
        Path.Combine(environmentVariablesSourceDirectory.GetPath(), codeBaseValue)
