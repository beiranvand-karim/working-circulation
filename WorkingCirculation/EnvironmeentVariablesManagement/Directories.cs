
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class Dictionaries 
    {
        public static string GetSriptsDirectoryName(IConfiguration config)
        {
            string scriptsDirectoryNameKey =
                config["EnvironmentVariablesCommandLineArgumentsNameKeys:ScriptsDirectoryNameKey"];
            string scriptsDirectoryName = Something.GetCommandLineArgByKey(scriptsDirectoryNameKey);
            return scriptsDirectoryName;
        }

        public static string GetEnvironmentVariablesSourceDirectoryName(IConfiguration config)
        {
            string environmentVariablesSourceDirectoryNameKey =
                config["EnvironmentVariablesCommandLineArgumentsNameKeys:EnvironmentVariablesSourceDirectoryNameKey"];

            string environmentVariablesSourceDirectoryName = Something.GetCommandLineArgByKey(environmentVariablesSourceDirectoryNameKey);

            string environmentVariablesSourceDirectory =
                Path.Combine(GetSriptsDirectoryName(config), environmentVariablesSourceDirectoryName);

            return environmentVariablesSourceDirectory;
        }

        public static string GetTemplatesDirectoryName(IConfiguration config)
        {
            string templatesDirectoryNameKey =
                config["EnvironmentVariablesCommandLineArgumentsNameKeys:TemplatesDirectoryNameKey"];

            string templatesDirectoryName = Something.GetCommandLineArgByKey(templatesDirectoryNameKey);
            return templatesDirectoryName;
        }

        public static string GetDestinationDirectoryName(IConfiguration config)
        {
            string destinationDirectoryNameKey =
            config["EnvironmentVariablesCommandLineArgumentsNameKeys:DestinationDirectoryNameKey"];
            
            string destinationDirectoryName = Something.GetCommandLineArgByKey(destinationDirectoryNameKey);
            return destinationDirectoryName;
        }

        public static string GetEnvironmeentVariablesManagementDirectoryName()
        {
            string repositoryDirectoryNameKey = "--repository-directory";
            string workingCirculationDirectoryName =
                Path.Combine(Something.GetCommandLineArgByKey(repositoryDirectoryNameKey), "WorkingCirculation");

            string environmeentVariablesManagementDirectoryName =
                Path.Combine(workingCirculationDirectoryName, "EnvironmeentVariablesManagement");

            return environmeentVariablesManagementDirectoryName;
        }

    }
}