
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class BatchScriptsDicrectory 
    {
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

        public static void CopyContentToTargetDicrectory(IConfiguration configuration){
            string sourceDirectory = CreatePathToSelf(configuration);
            string destinationDirectory = TargetDirectory.CreatePathToSelf();

            Directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public static string CreatePathToSelf(IConfiguration configuration){
            string scriptsDirectoryName = SriptsDirectory.GetName(configuration);
            string batchScriptsDirectoryPath = Path.Combine(scriptsDirectoryName, "batch-scripts");
            return batchScriptsDirectoryPath;
        }                
    }
}