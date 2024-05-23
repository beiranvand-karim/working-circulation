using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class PowerShellScriptsDirectory
    {
        public static void replaceFileNamesWithPaths(IConfiguration configuration)
        {
            string direcName = "powershell-scripts";
            string pathInTarget = ConstructPathToSelfInFeatureNameDirectory(configuration, direcName);
            string giversPath = EnvironmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory(configuration);
            foreach (string filePath in Directory.EnumerateFiles(pathInTarget)) 
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string giverFileName = $"""{fileName}.env""";
                string giverPath = Path.Combine(giversPath, giverFileName);
                Directories.replaceFileNameWithPath(filePath, giverPath);
            }
        }

        public static void replaceFileNamesWithPaths()
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

        public static void CopyContentToFeatureNameDicrectory(IConfiguration configuration){
            string direcName = "powershell-scripts";
            Directory.CreateDirectory(ConstructPathToSelfInFeatureNameDirectory(configuration, direcName));
            string sourceDirectory = ConstructPathToSelfInScriptsDirectory(configuration, direcName);
            string destinationDirectory = ConstructPathToSelfInFeatureNameDirectory(configuration, direcName);
          
            Directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
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
            string scriptsDirectoryName = ScriptsDirectory.GetName(configuration);
            string environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, direcName);
            return environmentVariablesFilesDirectory;
        }

        public static string ConstructPathToSelfInFeatureNameDirectory(IConfiguration configuration, string direcName)
        {
            string destinationDirectory = FeatureNameDirectory.GetPath(configuration);
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, direcName);
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
            string scriptsDirectoryName = ScriptsDirectory.GetName(configuration);
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