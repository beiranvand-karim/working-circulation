namespace cafdemwimu.console.Files.Executables

open Microsoft.Extensions.Logging
open cafdemwimu.console

type IdeExecutiveFileLocation(logger: ILogger<IdeExecutiveFileLocation>) =
    member _.GetPath() =
        let ideExecuteFileLocation = CommandLineArgs.GetByKey("--ide-execute-file-location")
        logger.LogInformation("ide execute file location: {ideExecuteFileLocation}", ideExecuteFileLocation)
        ideExecuteFileLocation
