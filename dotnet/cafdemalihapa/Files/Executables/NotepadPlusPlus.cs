using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Files.Executables
{
    public class NotepadPlusPlus(
        ILogger<NotepadPlusPlus> logger
    )
    {
        public string GetPath()
        {
            var notePadPlusPlusExecuteFileLocation = CommandLineArgs.GetByKey("--notepaddpp-execute-file-location");
            logger.LogInformation("Note pad plus plus execute file location: {notePadPlusPlusExecuteFileLocation}", notePadPlusPlusExecuteFileLocation);
            return notePadPlusPlusExecuteFileLocation;
        }
    }
}