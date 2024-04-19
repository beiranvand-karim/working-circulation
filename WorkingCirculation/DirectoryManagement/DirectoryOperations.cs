using System.Diagnostics;

namespace DirectoryManagement
{
    internal class DirectoryOperations {
        public static void OpenDirectoryThroughExplorer(string directoryPath){
            if(Directory.Exists(directoryPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = directoryPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }

        }
    }
}