using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DirectoryManagement
{
    public class DirectoryToBeOpen(
        IConfiguration configuration,
        ICommandLineArgs commandLineArgs,
        ILogger<DirectoryToBeOpen> logger
        ) : IDirectoryToBeOpen
    {
        private readonly IConfiguration configuration = configuration;
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly ILogger<DirectoryToBeOpen> logger = logger;

        string IDirectoryToBeOpen.GetPath()
        {
            var directoryToBeOpen = commandLineArgs.GetByKey("--directory-to-be-open");
            logger.LogInformation("directory to be open: {directoryToBeOpen}", directoryToBeOpen);
            return directoryToBeOpen;
        }
    }
}