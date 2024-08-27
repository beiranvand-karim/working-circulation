using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace DirectoryManagement
{
    public interface IDirectoryOperations
    {
        public void OpenDirectoryThroughExplorer(string directoryPath);

        public void OpenDirectoryThroughCommandLine(string commandToExecute, string workingDirectory);
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

        public void OpenDirectoryThroughCommandLine(string commandToExecute, string workingDirectory)
        {
            Process process = new();
            process.StartInfo.WorkingDirectory = workingDirectory;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c {commandToExecute}";
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
        }
    }
}