using Microsoft.Extensions.Logging;

namespace DirectoryManagement
{
    public interface IDirectoryManager
    {
        public void Run();
    }

    public class DirectoryManager(
            ILogger<DirectoryManager> logger,
            IDirectoryOperations directoryOperations,
            IDirectoryToBeOpen directoryToBeOpen
        ) : IDirectoryManager
    {
        private readonly ILogger<DirectoryManager> logger = logger;
        private readonly IDirectoryOperations directoryOperations = directoryOperations;
        private readonly IDirectoryToBeOpen directoryToBeOpen = directoryToBeOpen;

        public void Run()
        {
            try
            {
                string workingDirectory = directoryToBeOpen.GetPath();
                directoryOperations.OpenDirectoryThroughExplorer(workingDirectory);
            }
            catch (Exception exception)
            {
                logger.LogInformation("Exception: {exception}", exception);
            }

        }
    }
}