using Microsoft.Extensions.Logging;

namespace notepad_plus_plus_file_management
{
    public class DirectoryOperations(ILogger<DirectoryOperations> logger) : IDirectoryOperations
    {
        private readonly ILogger<DirectoryOperations> logger = logger;

        public void ListFilesToConsole(string sourceDirectory)
        {
            foreach (string file in Directory.EnumerateFiles(sourceDirectory))
            {
                logger.LogInformation("{file}", file);
            }
        }
    }
}