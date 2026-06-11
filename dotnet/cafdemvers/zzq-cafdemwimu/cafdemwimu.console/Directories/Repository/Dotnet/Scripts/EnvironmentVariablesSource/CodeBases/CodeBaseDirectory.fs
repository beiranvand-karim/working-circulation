namespace cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource.CodeBases

open System.IO
open cafdemwimu.console.Applications.Cafdemalihapa
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource

type CodeBaseDirectory(environmentVariablesSourceDirectory: EnvironmentVariablesSourceDirectory, codeBase: CodeBase) =
    member _.GetPath() =
        let codeBaseValue = codeBase.GetCodeBaseValue()
        Path.Combine(environmentVariablesSourceDirectory.GetPath(), codeBaseValue)
