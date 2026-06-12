namespace cafdemwimu.console.Directories.Hosting

open cafdemwimu.console
open cafdemwimu.console.Helpers

[<AbstractClass; Sealed>]
type HostingDirectory private () =
    static member GetPath() =
        let hostingDirectoryPath = CommandLineArgs.GetByKey("--hosting-directory")
        hostingDirectoryPath

    static member GetWrappedPath(stringHelpers: StringHelpers) : string =
        let hostingDirectoryPath = HostingDirectory.GetPath()
        let wrappedHostingDirectory = stringHelpers.WrapInQuotationMarks(hostingDirectoryPath)
        wrappedHostingDirectory
