namespace cafdemwimu.console.Directories.Repository

open cafdemwimu.console

type RepositoryDirectory() =
    member _.GetPath() =
        let repositoryDirectoryPath = CommandLineArgs.GetByKey("--repository-directory")
        repositoryDirectoryPath
