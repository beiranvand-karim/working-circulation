
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class Directories 
    {
        public static string CreatePathToTargetDirectory()
        {
            string environmeentVariablesManagementDirectoryName = GetEnvironmeentVariablesManagementDirectoryName();
            string targetDirectoryPath = Path.Combine(environmeentVariablesManagementDirectoryName, "target");
            return targetDirectoryPath;
        }

        public static void CreateFeatureNameDirectory(IConfiguration config)
        {
            string featureNameDirectoryNameKey =  CommandLineArgs.GetKey(config, "FeatureNameKey");
            string featureNameDirectoryName = CommandLineArgs.GetByKey(featureNameDirectoryNameKey);
            string hostingDirectoryName = GetHostingDirectoryName(config);
            string featureNameDirectoryPath = Path.Combine(hostingDirectoryName, featureNameDirectoryName);
            Directory.CreateDirectory(featureNameDirectoryPath);

        }
        public static string GetHostingDirectoryName(IConfiguration config)
        {
            string hostingDirectoryNameKey = CommandLineArgs.GetKey(config, "HostingDirectoryNameKey");
            string hostingDirectoryName = CommandLineArgs.GetByKey(hostingDirectoryNameKey);
            return hostingDirectoryName;
        }

        public static string GetSriptsDirectoryName(IConfiguration config)
        {
            string scriptsDirectoryNameKey = CommandLineArgs.GetKey(config, "ScriptsDirectoryNameKey");
            string scriptsDirectoryName = CommandLineArgs.GetByKey(scriptsDirectoryNameKey);
            return scriptsDirectoryName;
        }

        public static string GetEnvironmentVariablesSourceDirectoryName(IConfiguration config)
        {
             string environmentVariablesSourceDirectoryNameKey =
                CommandLineArgs.GetKey(config, "EnvironmentVariablesSourceDirectoryNameKey");         

            string environmentVariablesSourceDirectoryName = CommandLineArgs.GetByKey(environmentVariablesSourceDirectoryNameKey);

            string environmentVariablesSourceDirectory =
                Path.Combine(GetSriptsDirectoryName(config), environmentVariablesSourceDirectoryName);

            return environmentVariablesSourceDirectory;
        }

        public static string GetTemplatesDirectoryName(IConfiguration config)
        {
            string templatesDirectoryNameKey =
                CommandLineArgs.GetKey(config, "TemplatesDirectoryNameKey");

            string templatesDirectoryName = CommandLineArgs.GetByKey(templatesDirectoryNameKey);
            return templatesDirectoryName;
        }

        public static string GetDestinationDirectoryName(IConfiguration config)
        {
            string destinationDirectoryNameKey =
                CommandLineArgs.GetKey(config, "DestinationDirectoryNameKey");            
            
            string destinationDirectoryName = CommandLineArgs.GetByKey(destinationDirectoryNameKey);
            return destinationDirectoryName;
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