

using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class EnvironmentVariablesFilesDirectory
    {
        public static void CopyContentToFeatureNameDicrectory(IConfiguration configuration){
            string sourceDirectory = CreatePathToSelfInScriptsDirectory(configuration);
            string destinationDirectory = CreatePathToSelfInFeatureNameDirectory(configuration);

            Directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public static void CopyContentToTargetDicrectory(IConfiguration configuration){
            string sourceDirectory = CreatePathToSelfInScriptsDirectory(configuration);
            string destinationDirectory = CreatePathToSelfInTargetDirectory();

            Directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public static string CreatePathToSelfInScriptsDirectory(IConfiguration configuration)
        {
            string scriptsDirectoryName = ScriptsDirectory.GetName(configuration);
            string environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public static string CreatePathToSelfInFeatureNameDirectory(IConfiguration configuration)
        {
            string destinationDirectory = FeatureNameDirectory.GetPath(configuration);
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public static string CreatePathToSelfInTargetDirectory()
        {
            string destinationDirectory = TargetDirectory.CreatePathToSelf();
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