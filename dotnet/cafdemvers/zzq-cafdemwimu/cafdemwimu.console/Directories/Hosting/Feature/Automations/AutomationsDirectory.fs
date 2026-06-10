namespace cafdemwimu.console.Directories.Hosting.Feature.Automations

open System.IO
open cafdemwimu.console.Directories.Hosting.Feature

type AutomationsDirectory() =
    member this.Create() =
        let path = this.GetPath()
        Directory.CreateDirectory(path) |> ignore

    member _.GetPath() =
        let directory = FeatureDirectory.GetPath()
        let automationsDirectory = Path.Combine(directory, "automations")
        automationsDirectory
