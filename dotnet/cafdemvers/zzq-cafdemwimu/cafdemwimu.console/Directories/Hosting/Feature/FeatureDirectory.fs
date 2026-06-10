namespace cafdemwimu.console.Directories.Hosting.Feature

open System.IO
open cafdemwimu.console
open cafdemwimu.console.Directories.Hosting

[<AbstractClass; Sealed>]
type FeatureDirectory private () =
    static member Create() =
        let featureDirectoryPath = FeatureDirectory.GetPath()
        Directory.CreateDirectory(featureDirectoryPath) |> ignore

    static member GetPath() =
        let featureName = CommandLineArgs.GetByKey("--feature-name")
        let hostingDirectoryName = HostingDirectory.GetPath()
        let featureDirectoryPath = Path.Combine(hostingDirectoryName, featureName)
        featureDirectoryPath
