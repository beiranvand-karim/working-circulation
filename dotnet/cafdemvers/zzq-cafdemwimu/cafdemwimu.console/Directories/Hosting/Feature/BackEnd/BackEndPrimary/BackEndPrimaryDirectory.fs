namespace cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndPrimary

open System.IO
open cafdemwimu.console.Names
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd

type BackEndPrimaryDirectory(primaryApplication: PrimaryApplication) =
    member _.GetName() =
        let backEndDirectoryName = BackEndDirectory.GetName()
        let primaryApplicationName = primaryApplication.GetName()
        let name = $"{backEndDirectoryName}.{primaryApplicationName}"
        name

    member this.GetPath() =
        let backEndDirectoryPath = BackEndDirectory.GetPath()
        let name = this.GetName()
        let backEndPrimaryDirectoryPath = Path.Combine(backEndDirectoryPath, name)
        backEndPrimaryDirectoryPath

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore
