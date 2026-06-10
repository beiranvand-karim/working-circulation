namespace cafdemwimu.console.Directories.Hosting.Feature.WebLinks

open System.IO
open cafdemwimu.console.Directories.Hosting.Feature

type WebLinksDirectory() =
    member _.GetPath() =
        let directoryName = "web links"
        let featureDirectoryPath = FeatureDirectory.GetPath()
        let notesAndMessages = Path.Combine(featureDirectoryPath, directoryName)
        notesAndMessages

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore
