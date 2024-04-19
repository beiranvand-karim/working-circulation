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

        public static void OpenDirectoryThroughCommandLine(string commandToExecute, string workingDirectory) {
            Process process = new Process();
            process.StartInfo.WorkingDirectory = workingDirectory;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c {commandToExecute}";
            process.StartInfo.RedirectStandardOutput= true;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
        }
    }
}