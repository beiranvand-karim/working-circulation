namespace cafdemwimu.console.Directories.Hosting.Feature.BackEnd

open System.IO
open cafdemwimu.console.Directories.Hosting.Feature

[<AbstractClass; Sealed>]
type BackEndDirectory private () =
    static member GetName() = "bend"

    static member GetPath() =
        let directoryName = BackEndDirectory.GetName()
        let featureDirectoryPath = FeatureDirectory.GetPath()
        let notesAndMessages = Path.Combine(featureDirectoryPath, directoryName)
        notesAndMessages

    static member Create() =
        let path = BackEndDirectory.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore
