namespace cafdemwimu.console.Directories.Hosting.Feature.FrontEnd

open System.IO
open cafdemwimu.console.Directories.Hosting.Feature

type FrontEndDirectory() =
    member _.GetName() = "fend"

    member this.GetPath() =
        let directoryName = this.GetName()
        let featureDirectoryPath = FeatureDirectory.GetPath()
        let frontEndDirectoryPath = Path.Combine(featureDirectoryPath, directoryName)
        frontEndDirectoryPath

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore
