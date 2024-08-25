using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using notepad_plus_plus_file_management.Files.Executabes.Interfaces;
using notepad_plus_plus_file_management.Interfaces;

namespace notepad_plus_plus_file_management.Files.Executabes.Classes
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