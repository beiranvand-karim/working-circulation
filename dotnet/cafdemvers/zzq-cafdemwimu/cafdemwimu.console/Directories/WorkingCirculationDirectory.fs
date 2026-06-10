namespace cafdemwimu.console.Directories

open System.IO
open cafdemwimu.console

type WorkingCirculationDirectory() =
    member private _.GetPath() =
        let repositoryDirectoryNameKey = "--repository-directory"
        let workingCirculationDirectoryName =
            Path.Combine(CommandLineArgs.GetByKey(repositoryDirectoryNameKey), "WorkingCirculation")
        workingCirculationDirectoryName

    member this.GetName() =
        let workingCirculationDirectoryName = this.GetPath()
        let environmentVariablesManagementDirectoryName =
            Path.Combine(workingCirculationDirectoryName, "EnvironmentVariablesManagement")
        environmentVariablesManagementDirectoryName
