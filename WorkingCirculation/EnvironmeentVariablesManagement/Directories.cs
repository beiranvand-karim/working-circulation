
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class Directories 
    {
        public static void CopyFileToDestinationDirectory(string file, string destinationDirectory)
        {
            string fileName = Path.GetFileName(file);
            string destFileName = Path.GetFileName(fileName);
            string destFilePathIncludingName = Path.Combine(destinationDirectory, destFileName);
            File.Copy(file, destFilePathIncludingName);
        }

        public static void CopyContentOfSourceDireectoryToDestinationDirectory(string sourceDirectory, string destinationDirectory)
        {
            foreach (string file in Directory.EnumerateFiles(sourceDirectory))
            {
                CopyFileToDestinationDirectory(file, destinationDirectory);
            }
        }

        public static string GetHostingDirectoryName(IConfiguration config)
        {
            string hostingDirectoryNameKey = CommandLineArgs.GetKey(config, "HostingDirectoryNameKey");
            string hostingDirectoryName = CommandLineArgs.GetByKey(hostingDirectoryNameKey);
            return hostingDirectoryName;
        }

        public static string GetTemplatesDirectoryName(IConfiguration config)
        {
            string templatesDirectoryNameKey =
                CommandLineArgs.GetKey(config, "TemplatesDirectoryNameKey");

            string templatesDirectoryName = CommandLineArgs.GetByKey(templatesDirectoryNameKey);
            return templatesDirectoryName;
        }

        public static string GetEnvironmeentVariablesManagementDirectoryName()
        {
            string workingCirculationDirectoryName = CreatePathToWorkingCirculationDirectory();

            string environmeentVariablesManagementDirectoryName =
                Path.Combine(workingCirculationDirectoryName, "EnvironmeentVariablesManagement");

            return environmeentVariablesManagementDirectoryName;
        }

        public static string CreatePathToWorkingCirculationDirectory()
        {
            string repositoryDirectoryNameKey = "--repository-directory";
            string workingCirculationDirectoryName =
                Path.Combine(CommandLineArgs.GetByKey(repositoryDirectoryNameKey), "WorkingCirculation");
            return workingCirculationDirectoryName;         
        }        
    }
}