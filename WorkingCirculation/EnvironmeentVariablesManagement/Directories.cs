
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class Dictionaries 
    {
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
            string repositoryDirectoryNameKey = "--repository-directory";
            string workingCirculationDirectoryName =
                Path.Combine(CommandLineArgs.GetByKey(repositoryDirectoryNameKey), "WorkingCirculation");

            string environmeentVariablesManagementDirectoryName =
                Path.Combine(workingCirculationDirectoryName, "EnvironmeentVariablesManagement");

            return environmeentVariablesManagementDirectoryName;
        }
    }
}