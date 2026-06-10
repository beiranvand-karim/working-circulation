namespace cafdemwimu.console.Directories

open System.IO
open cafdemwimu.console

type WorkingDirectory() =
    member _.GetPath() =
        let workingDirectoryNameKey = "--working-directory"
        let workingDirectoryName =
            CommandLineArgs.GetByKey(workingDirectoryNameKey)
        workingDirectoryName
