
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class BatchScriptsDicrectory 
    {
        public static void CopyToTargetDicrectory(IConfiguration configuration){
            string sourceDirectory = CreatePathToSelf(configuration);
            string destinationDirectory = TargetDirectory.CreatePathToSelf();

            Directories.CopyContentOfSourceDireectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public static string CreatePathToSelf(IConfiguration configuration){
            string scriptsDirectoryName = SriptsDirectory.GetName(configuration);
            string batchScriptsDirectoryPath = Path.Combine(scriptsDirectoryName, "batch-scripts");
            return batchScriptsDirectoryPath;
        }                
    }
}