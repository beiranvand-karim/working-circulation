namespace cafdemwimu.console.Directories.Hosting.Feature.Calls

open System.IO
open cafdemwimu.console.Directories.Hosting.Feature

type CallsDirectory() =
    member _.GetPath() =
        let directoryName = "calls"
        let featureDirectoryPath = FeatureDirectory.GetPath()
        let notesAndMessages = Path.Combine(featureDirectoryPath, directoryName)
        notesAndMessages

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore
