
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class BatchScriptsDicrectory 
    {
        internal static void replaceFileNamesWithPaths(IConfiguration configuration)
        {            
            string pathToTarget = FeatureNameDirectory.GetPath(configuration);
            string giversPath = PowerShellScriptsDirectory.ConstructPathToSelfInFeatureNameDirectory(configuration, "powershell-scripts");
            foreach (string filePath in Directory.EnumerateFiles(pathToTarget)) 
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string giverFileName = $"""{fileName}.ps1""";
                string giverPath = Path.Combine(giversPath, giverFileName);
                Directories.replaceFileNameWithPath(filePath, giverPath);
            }
        }

        internal static void replaceFileNamesWithPaths()
        {            
            string pathToTarget = TargetDirectory.CreatePathToSelf();
            string giversPath = PowerShellScriptsDirectory.ConstructPathToSelfInTargetDirectory();
            foreach (string filePath in Directory.EnumerateFiles(pathToTarget)) 
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string giverFileName = $"""{fileName}.ps1""";
                string giverPath = Path.Combine(giversPath, giverFileName);
                Directories.replaceFileNameWithPath(filePath, giverPath);
            }
        }

        public static string ConstructPathToSelfInTargetDirectory(string direcName)
        {
            string destinationDirectory = TargetDirectory.CreatePathToSelf();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, direcName);
            return environmentVariablesFilesDirectory;
        }

        public static string CreatePathToSelfInFeatureNameDirector(IConfiguration configuration){
            string scriptsDirectoryName = ScriptsDirectory.GetName(configuration);
            string batchScriptsDirectoryPath = Path.Combine(scriptsDirectoryName, "batch-scripts");
            return batchScriptsDirectoryPath;
        }  

        public static void CopyContentToFeaureNameDicrectory(IConfiguration configuration)
        {
            string sourceDirectory = CreatePathToSelfInScriptsDirectory(configuration);
            string destinationDirectory = FeatureNameDirectory.GetPath(configuration);

            Directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public static void CopyContentToTargetDicrectory(IConfiguration configuration)
        {
            string sourceDirectory = CreatePathToSelfInScriptsDirectory(configuration);
            string destinationDirectory = TargetDirectory.CreatePathToSelf();

            Directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public static string CreatePathToSelfInScriptsDirectory(IConfiguration configuration){
            string scriptsDirectoryName = ScriptsDirectory.GetName(configuration);
            string batchScriptsDirectoryPath = Path.Combine(scriptsDirectoryName, "batch-scripts");
            return batchScriptsDirectoryPath;
        }                
    }
}