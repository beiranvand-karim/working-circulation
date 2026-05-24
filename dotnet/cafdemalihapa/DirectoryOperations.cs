using Microsoft.Extensions.Logging;

namespace cafdemalihapa
{
    public class DirectoryOperations(ILogger<DirectoryOperations> logger)
    {
        public void ListFilesToConsole(string sourceDirectory)
        {
            foreach (var file in Directory.EnumerateFiles(sourceDirectory))
            {
                logger.LogInformation("{file}", file);
            }
        }
    }
}