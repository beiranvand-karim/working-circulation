namespace cafdemwimu.console.Applications.DirectoryManagement.DirectoryOpenStrategies

open System.Runtime.InteropServices
open Microsoft.Extensions.Logging

type LinuxDirectoryOpenStrategy(logger: ILogger<LinuxDirectoryOpenStrategy>) =
    inherit DirectoryOpenStrategy(logger)

    override _.FileName = "xdg-open"

    override _.CanHandle() = RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
