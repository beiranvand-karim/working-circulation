namespace cafdemwimu.console.Directories.Repository.Dotnet.Scripts

open cafdemwimu.console

type ScriptsDirectory() =
    member _.GetPath() =
        let scriptsDirectoryNameKey = "--scripts-directory"
        let scriptsDirectoryName =
            CommandLineArgs.GetByKey(scriptsDirectoryNameKey)
        scriptsDirectoryName
