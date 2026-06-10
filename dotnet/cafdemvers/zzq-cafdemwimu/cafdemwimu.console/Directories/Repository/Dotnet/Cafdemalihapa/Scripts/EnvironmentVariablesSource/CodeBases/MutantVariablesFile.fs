namespace cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.Files.Jsons

open System.IO
open cafdemwimu.console.Names
open cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.CodeBases

type MutantVariablesFile(primaryApplication: PrimaryApplication, secondaryApplication: SecondaryApplication, codeBaseDirectory: CodeBaseDirectory) =
    member _.GetName() =
        let primaryApplicationName = primaryApplication.GetName()
        let secondaryApplicationName = secondaryApplication.GetName()
        let fileName = $"{primaryApplicationName}-{secondaryApplicationName}.json"
        fileName

    member this.GetPath() =
        let name = this.GetName()
        Path.Combine(codeBaseDirectory.GetPath(), name)
