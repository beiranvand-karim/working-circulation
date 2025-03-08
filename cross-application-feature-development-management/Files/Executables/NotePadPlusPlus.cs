using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Files.Executables
{
    public class NotePadPlusPlus(
        IConfiguration configuration,
        CommandLineArgs commandLineArgs,
        ILogger<NotePadPlusPlus> logger
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