namespace cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndSecondary

open System.IO
open cafdemwimu.console.Files
open cafdemwimu.console.Names
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd

type FrontEndSecondaryDirectory(secondaryApplication: SecondaryApplication, frontEndDirectory: FrontEndDirectory) =
    member _.GetName() =
        let frontEndDirectoryName = frontEndDirectory.GetName()
        let secondaryApplicationName = secondaryApplication.GetName()
        let name = $"{frontEndDirectoryName}.{secondaryApplicationName}"
        name

    member this.GetPath() =
        let frontEndDirectoryPath = frontEndDirectory.GetPath()
        let name = this.GetName()
        let frontEndSecondaryDirectoryPath = Path.Combine(frontEndDirectoryPath, name)
        frontEndSecondaryDirectoryPath

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore

    member this.CreateFiles() =
        let path = this.GetPath()
        FileService.CreateNumberedFiles path
