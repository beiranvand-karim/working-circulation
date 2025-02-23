using cross_application_feature_development_management.Files.Interfaces;
using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Files.Executables
{
    public class NotePadPlusPlus(
        IConfiguration configuration,
        ICommandLineArgs commandLineArgs,
        ILogger<NotePadPlusPlus> logger
    ) : INotePadPlusPlus
    {
        private readonly IConfiguration configuration = configuration;
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly ILogger<NotePadPlusPlus> logger = logger;

        public string GetPath()
        {
            var notePadPlusPlusExecuteFileLocation = commandLineArgs.GetByKey("--notepaddpp-execute-file-location");
            logger.LogInformation("Note pad plus plus execute file location: {notePadPlusPlusExecuteFileLocation}", notePadPlusPlusExecuteFileLocation);
            return notePadPlusPlusExecuteFileLocation;
        }
    }
}