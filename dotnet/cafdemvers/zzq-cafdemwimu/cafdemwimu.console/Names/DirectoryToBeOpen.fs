namespace cafdemwimu.console.Names

open Microsoft.Extensions.Logging
open cafdemwimu.console

type DirectoryToBeOpen(logger: ILogger<DirectoryToBeOpen>) =
    member _.GetPath() =
        let directoryToBeOpen = CommandLineArgs.GetByKey("--directory-to-be-open")
        logger.LogInformation("directory to be open: {directoryToBeOpen}", directoryToBeOpen)
        directoryToBeOpen
