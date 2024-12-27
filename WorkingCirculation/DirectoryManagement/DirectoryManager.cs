using Microsoft.Extensions.Logging;

namespace DirectoryManagement
{
    public interface IDirectoryManager
    {
        public void Run();
    }

    public class DirectoryManager(ILogger<DirectoryManager> logger, IDirectoryOperations directoryOperations) : IDirectoryManager
    {
        private readonly ILogger<DirectoryManager> logger = logger;
        private readonly IDirectoryOperations directoryOperations = directoryOperations;

        public void Run()
        {
            try
            {
                string choice = "2";
                string workingDirectory = Environment.GetCommandLineArgs()[1];

                if (choice == "1")
                {
                    string commandToExecute = Environment.GetCommandLineArgs()[2];
                    directoryOperations.OpenDirectoryThroughCommandLine(commandToExecute, workingDirectory);
                }

                if (choice == "2")
                {
                    directoryOperations.OpenDirectoryThroughExplorer(workingDirectory);
                }
            }
            catch (Exception exception)
            {
                logger.LogInformation("Exception: {exception}", exception);
            }

        }
    }
}