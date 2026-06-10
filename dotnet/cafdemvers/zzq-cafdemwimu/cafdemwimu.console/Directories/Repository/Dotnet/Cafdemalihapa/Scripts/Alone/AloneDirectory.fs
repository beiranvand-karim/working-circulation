namespace cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.Alone

open System.IO
open cafdemwimu.console.Names
open cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts

type AloneDirectory(secondaryApplication: SecondaryApplication, scriptsDirectory: ScriptsDirectory) =
    member _.GetName() =
        let primaryDirectory =
            Path.Combine(scriptsDirectory.GetPath(), "primary")

        let templateSourceDirectory =
            Path.Combine(primaryDirectory, "environment-variables-template-files")

        templateSourceDirectory

    member this.AloneOrDouble() =
        let x = secondaryApplication.GetName()
        if x.Contains("couldn") then "alone" else "double"

    member this.IsAlone() =
        this.AloneOrDouble() = "alone"
