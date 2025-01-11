using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management
{
    public class DirectoryOperations(ILogger<DirectoryOperations> logger) : IDirectoryOperations
    {
        private readonly ILogger<DirectoryOperations> logger = logger;

        public void ListFilesToConsole(string sourceDirectory)
        {
            foreach (var file in Directory.EnumerateFiles(sourceDirectory))
            {
                logger.LogInformation("{file}", file);
            }
        }
    }
}