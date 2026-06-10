namespace cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndSecondary

open System.IO
open cafdemwimu.console.Names
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd

type BackEndSecondaryDirectory(secondaryApplication: SecondaryApplication) =
    member _.GetName() =
        let backEndDirectoryName = BackEndDirectory.GetName()
        let secondaryApplicationName = secondaryApplication.GetName()
        let name = $"{backEndDirectoryName}.{secondaryApplicationName}"
        name

    member this.GetPath() =
        let backEndDirectoryPath = BackEndDirectory.GetPath()
        let name = this.GetName()
        let backEndSecondaryDirectoryPath = Path.Combine(backEndDirectoryPath, name)
        backEndSecondaryDirectoryPath

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore
