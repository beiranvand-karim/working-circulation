namespace cafdemwimu.console.Applications.DirectoryManagement.DirectoryOpenStrategies

open System.Runtime.InteropServices
open Microsoft.Extensions.Logging
open cafdemwimu.console.Applications

type WindowsDirectoryOpenStrategy(logger: ILogger<WindowsDirectoryOpenStrategy>) =
    inherit DirectoryOpenStrategy(logger)

    override _.FileName = "explorer.exe"

    override _.TransformPath(path) =
        PathUtility.NormalizeSlashes(path, PathUtility.SlashStyle.ForceBackslash)

    override _.CanHandle() = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
