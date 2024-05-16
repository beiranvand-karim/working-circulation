

using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class EnvironmentVariablesFilesDirectory
    {
        public static void CopyEnvironmentVariablesFilesDirectoryContentToTargetDicrectory(IConfiguration configuration){
            string sourceDirectory = CreatePathToEnvironmentVariablesFilesDirectoryInScriptsDirectory(configuration);
            string destinationDirectory = CreatePathToEnvironmentVariablesFilesDirectoryInTargetDirectory();

            Directories.CopyContentOfSourceDireectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public static string CreatePathToEnvironmentVariablesFilesDirectoryInScriptsDirectory(IConfiguration configuration)
        {
            string scriptsDirectoryName = Directories.GetSriptsDirectoryName(configuration);
            string environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public static string CreatePathToEnvironmentVariablesFilesDirectoryInTargetDirectory()
        {
            string destinationDirectory = Directories.CreatePathToTargetDirectory();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }
    }
}