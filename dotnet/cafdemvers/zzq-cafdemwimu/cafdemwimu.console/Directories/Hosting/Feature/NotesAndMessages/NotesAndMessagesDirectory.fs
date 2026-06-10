namespace cafdemwimu.console.Directories.Hosting.Feature.NotesAndMessages

open System.IO
open cafdemwimu.console.Files
open cafdemwimu.console.Directories.Hosting.Feature

type NotesAndMessagesDirectory() =
    member _.GetPath() =
        let directoryName = "notes and messages"
        let featureDirectoryPath = FeatureDirectory.GetPath()
        let notesAndMessages = Path.Combine(featureDirectoryPath, directoryName)
        notesAndMessages

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore

    member this.CreateFiles() =
        let path = this.GetPath()
        FileService.CreateNumberedFiles path
