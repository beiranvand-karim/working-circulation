namespace cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndPrimary

open System.IO
open cafdemwimu.console.Files
open cafdemwimu.console.Names
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd

type FrontEndPrimaryDirectory(frontEndDirectory: FrontEndDirectory, primaryApplication: PrimaryApplication) =
    member _.GetName() =
        let frontEndDirectoryName = frontEndDirectory.GetName()
        let primaryApplicationName = primaryApplication.GetName()
        let name = $"{frontEndDirectoryName}.{primaryApplicationName}"
        name

    member this.GetPath() =
        let frontEndDirectoryPath = frontEndDirectory.GetPath()
        let name = this.GetName()
        let frontEndPrimaryDirectoryPath = Path.Combine(frontEndDirectoryPath, name)
        frontEndPrimaryDirectoryPath

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore

    member this.CreateFiles() =
        let path = this.GetPath()
        FileService.CreateNumberedFiles path
