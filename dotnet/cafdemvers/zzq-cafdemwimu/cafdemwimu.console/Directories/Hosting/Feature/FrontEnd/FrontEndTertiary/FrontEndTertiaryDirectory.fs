namespace cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndTertiary

open System.IO
open cafdemwimu.console.Files
open cafdemwimu.console.Names
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd

type FrontEndTertiaryDirectory(tertiaryApplication: TertiaryApplication, frontEndDirectory: FrontEndDirectory) =
    member _.GetName() =
        let frontEndDirectoryName = frontEndDirectory.GetName()
        let tertiaryApplicationName = tertiaryApplication.GetName()
        let name = $"{frontEndDirectoryName}.{tertiaryApplicationName}"
        name

    member this.GetPath() =
        let frontEndDirectoryPath = frontEndDirectory.GetPath()
        let name = this.GetName()
        let frontEndTertiaryDirectoryPath = Path.Combine(frontEndDirectoryPath, name)
        frontEndTertiaryDirectoryPath

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore

    member this.CreateFiles() =
        let path = this.GetPath()
        FileService.CreateNumberedFiles path
