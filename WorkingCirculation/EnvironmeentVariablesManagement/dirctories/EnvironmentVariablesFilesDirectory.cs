

using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class EnvironmentVariablesFilesDirectory
    {
        public static void CopyContentToTargetDicrectory(IConfiguration configuration){
            string sourceDirectory = CreatePathToSelfInScriptsDirectory(configuration);
            string destinationDirectory = CreatePathToSelfInTargetDirectory();

            Directories.CopyContentOfSourceDireectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public static string CreatePathToSelfInScriptsDirectory(IConfiguration configuration)
        {
            string scriptsDirectoryName = Directories.GetSriptsDirectoryName(configuration);
            string environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public static string CreatePathToSelfInTargetDirectory()
        {
            string destinationDirectory = Directories.CreatePathToTargetDirectory();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public static string GetName(IConfiguration config)
        {
            string destinationDirectoryNameKey =
                CommandLineArgs.GetKey(config, "DestinationDirectoryNameKey");            
            
            string destinationDirectoryName = CommandLineArgs.GetByKey(destinationDirectoryNameKey);
            return destinationDirectoryName;
        }        
    }
}