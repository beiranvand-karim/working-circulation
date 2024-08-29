using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace DirectoryManagement
{
    public interface IDirectoryOperations
    {
        public void OpenDirectoryThroughExplorer(string directoryPath);

    }
    public class DirectoryOperations(ILogger<DirectoryOperations> logger) : IDirectoryOperations
    {
        private readonly ILogger<DirectoryOperations> logger = logger;

        public void OpenDirectoryThroughExplorer(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                ProcessStartInfo startInfo = new()
                {
                    Arguments = directoryPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }

        }
    }
}