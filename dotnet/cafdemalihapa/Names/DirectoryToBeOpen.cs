using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Names
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