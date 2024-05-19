using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class PowerShellScriptsDirectory
    {
        public static void replaceFileNameWithPath(string receiverPath, string giverPath)
        {
            string fileName= Path.GetFileName(giverPath);
            string text = File.ReadAllText(receiverPath);
            text = text.Replace(fileName, giverPath);
            File.WriteAllText(receiverPath, text);
        }

        public static void CopyContentToTargetDicrectory(IConfiguration configuration){
            string direcName = "powershell-scripts";
            Directory.CreateDirectory(ConstructPathToSelfInTargetDirectory(direcName));
            string sourceDirectory = ConstructPathToSelfInScriptsDirectory(configuration, direcName);
            string destinationDirectory = ConstructPathToSelfInTargetDirectory(direcName);

            Directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }
        public static string ConstructPathToSelfInScriptsDirectory(IConfiguration configuration, string direcName)
        {
            string scriptsDirectoryName = SriptsDirectory.GetName(configuration);
            string environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, direcName);
            return environmentVariablesFilesDirectory;
        }

        public static string ConstructPathToSelfInTargetDirectory(string direcName)
        {
            string destinationDirectory = TargetDirectory.CreatePathToSelf();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, direcName);
            return environmentVariablesFilesDirectory;
        }

        public static string ConstructPathToSelfInScriptsDirectory(IConfiguration configuration)
        {
            string scriptsDirectoryName = SriptsDirectory.GetName(configuration);
            string environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, "powershell-scripts");
            return environmentVariablesFilesDirectory;
        }

        public static string ConstructPathToSelfInTargetDirectory()
        {
            string destinationDirectory = TargetDirectory.CreatePathToSelf();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "powershell-scripts");
            return environmentVariablesFilesDirectory;
        }
    }
}