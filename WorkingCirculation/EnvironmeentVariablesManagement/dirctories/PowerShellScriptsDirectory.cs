using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class PowerShellScriptsDirectory
    {
        internal static void replaceFileNamesWithPaths()
        {            
            string direcName = "powershell-scripts";
            string pathInTarget = ConstructPathToSelfInTargetDirectory(direcName);
            string giversPath = EnvironmentVariablesFilesDirectory.CreatePathToSelfInTargetDirectory();
            foreach (string filePath in Directory.EnumerateFiles(pathInTarget)) 
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string giverFileName = $"""{fileName}.env""";
                string giverPath = Path.Combine(giversPath, giverFileName);
                Directories.replaceFileNameWithPath(filePath, giverPath);
            }
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