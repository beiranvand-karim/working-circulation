namespace cafdemwimu.console.Directories.Hosting.Feature.Data

open System.IO
open cafdemwimu.console.Directories.Hosting.Feature

type DataDirectory() =
    member _.GetName() = "data"

    member this.GetPath() =
        let directoryName = this.GetName()
        let featureDirectoryPath = FeatureDirectory.GetPath()
        let dataDirectory = Path.Combine(featureDirectoryPath, directoryName)
        dataDirectory

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore
