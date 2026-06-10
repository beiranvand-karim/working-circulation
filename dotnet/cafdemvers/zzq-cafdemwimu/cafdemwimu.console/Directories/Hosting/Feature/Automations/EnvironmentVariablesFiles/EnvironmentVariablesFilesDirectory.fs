namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles

open System.IO
open System.Collections.Generic
open cafdemwimu.console.Applications
open cafdemwimu.console.Directories.Hosting.Feature.Automations

type EnvironmentVariablesFilesDirectory(automationsDirectory: AutomationsDirectory, something: Something) =
    member this.Create() =
        let path = this.GetPath()
        Directory.CreateDirectory(path) |> ignore

    member _.GetPath() =
        let destinationDirectory = automationsDirectory.GetPath()
        let environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "environment-variables-files")
        environmentVariablesFilesDirectory

    member _.PairUp() : Dictionary<string, string> =
        let environmentVariablesSourceDictionary = something.PairUpEnvironmentVariablesSeparationFilement()
        environmentVariablesSourceDictionary
