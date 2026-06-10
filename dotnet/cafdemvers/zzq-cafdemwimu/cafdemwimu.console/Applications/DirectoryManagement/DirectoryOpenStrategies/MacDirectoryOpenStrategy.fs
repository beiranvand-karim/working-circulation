namespace cafdemwimu.console.Applications.DirectoryManagement.DirectoryOpenStrategies

open System.Runtime.InteropServices
open Microsoft.Extensions.Logging

type MacDirectoryOpenStrategy(logger: ILogger<MacDirectoryOpenStrategy>) =
    inherit DirectoryOpenStrategy(logger)

    override _.FileName = "open"

    override _.CanHandle() = RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
