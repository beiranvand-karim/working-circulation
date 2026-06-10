namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.ProcessesMetaData

open System.IO
open cafdemwimu.console.Directories.Hosting.Feature.Automations

type ProcessesMetaDataDirectory(automationsDirectory: AutomationsDirectory) =
    member this.Create() =
        let path = this.GetPath()
        Directory.CreateDirectory(path) |> ignore

    member _.GetPath() =
        let directory = automationsDirectory.GetPath()
        let processesMetaDataDirectory = Path.Combine(directory, "processes-meta-data")
        processesMetaDataDirectory
