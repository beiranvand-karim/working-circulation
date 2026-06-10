namespace cafdemwimu.console.Directories.Hosting

open cafdemwimu.console

[<AbstractClass; Sealed>]
type HostingDirectory private () =
    static member GetPath() =
        let hostingDirectoryPath = CommandLineArgs.GetByKey("--hosting-directory")
        hostingDirectoryPath
