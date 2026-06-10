namespace cafdemwimu.console.Files.Executables

open Microsoft.Extensions.Logging
open cafdemwimu.console

type NotepadPlusPlus(logger: ILogger<NotepadPlusPlus>) =
    member _.GetPath() =
        let notePadPlusPlusExecuteFileLocation = CommandLineArgs.GetByKey("--notepaddpp-execute-file-location")
        logger.LogInformation("Note pad plus plus execute file location: {notePadPlusPlusExecuteFileLocation}", notePadPlusPlusExecuteFileLocation)
        notePadPlusPlusExecuteFileLocation
