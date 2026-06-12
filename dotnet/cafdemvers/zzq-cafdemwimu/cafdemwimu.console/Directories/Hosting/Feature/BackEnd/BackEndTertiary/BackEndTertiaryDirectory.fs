namespace cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndTertiary

open System.IO
open cafdemwimu.console.Names
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd

type BackEndTertiaryDirectory(tertiaryApplication: TertiaryApplication) =
    member _.GetName() =
        let backEndDirectoryName = BackEndDirectory.GetName()
        let tertiaryApplicationName = tertiaryApplication.GetName()
        let name = $"{backEndDirectoryName}.{tertiaryApplicationName}"
        name

    member this.GetPath() =
        let backEndDirectoryPath = BackEndDirectory.GetPath()
        let name = this.GetName()
        let backEndTertiaryDirectoryPath = Path.Combine(backEndDirectoryPath, name)
        backEndTertiaryDirectoryPath

    member this.Create() =
        let path = this.GetPath()
        if not (Directory.Exists(path)) then
            Directory.CreateDirectory(path) |> ignore
