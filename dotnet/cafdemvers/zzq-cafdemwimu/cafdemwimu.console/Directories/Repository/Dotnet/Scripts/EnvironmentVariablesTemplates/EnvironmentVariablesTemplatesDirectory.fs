namespace cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesTemplates

open System.IO
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.Alone

type EnvironmentVariablesTemplatesDirectory(aloneDirectory: AloneDirectory, scriptsDirectory: ScriptsDirectory) =
    member _.GetPath() =
        let templateSourceDirectory_construction =
            Path.Combine(scriptsDirectory.GetPath(), "environment-variables-template-files")

        let templateSourceDirectory =
            if aloneDirectory.IsAlone() then aloneDirectory.GetName()
            else templateSourceDirectory_construction

        templateSourceDirectory
