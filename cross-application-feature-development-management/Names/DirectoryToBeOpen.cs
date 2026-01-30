using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Names
{
    public class DirectoryToBeOpen(
        ILogger<DirectoryToBeOpen> logger
        )
    {
        public string GetPath()
        {
            var directoryToBeOpen = CommandLineArgs.GetByKey("--directory-to-be-open");
            logger.LogInformation("directory to be open: {directoryToBeOpen}", directoryToBeOpen);
            return directoryToBeOpen;
        }
    }
}