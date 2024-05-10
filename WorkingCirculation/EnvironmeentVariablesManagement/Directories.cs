
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class Dictionaries 
    {
        public static string GetSriptsDirectoryName(IConfiguration config)
        {
            string scriptsDirectoryNameKey =
                config["EnvironmentVariablesCommandLineArgumentsNameKeys:ScriptsDirectoryNameKey"];
            string scriptsDirectoryName = CommandLineArgs.GetByKey(scriptsDirectoryNameKey);
            return scriptsDirectoryName;
        }

        public static string GetEnvironmentVariablesSourceDirectoryName(IConfiguration config)
        {
            string environmentVariablesSourceDirectoryNameKey =
                config["EnvironmentVariablesCommandLineArgumentsNameKeys:EnvironmentVariablesSourceDirectoryNameKey"];

            string environmentVariablesSourceDirectoryName = CommandLineArgs.GetByKey(environmentVariablesSourceDirectoryNameKey);

            string environmentVariablesSourceDirectory =
                Path.Combine(GetSriptsDirectoryName(config), environmentVariablesSourceDirectoryName);

            return environmentVariablesSourceDirectory;
        }

        public static string GetTemplatesDirectoryName(IConfiguration config)
        {
            string templatesDirectoryNameKey =
                config["EnvironmentVariablesCommandLineArgumentsNameKeys:TemplatesDirectoryNameKey"];

            string templatesDirectoryName = CommandLineArgs.GetByKey(templatesDirectoryNameKey);
            return templatesDirectoryName;
        }

        public static string GetDestinationDirectoryName(IConfiguration config)
        {
            string destinationDirectoryNameKey =
            config["EnvironmentVariablesCommandLineArgumentsNameKeys:DestinationDirectoryNameKey"];
            
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