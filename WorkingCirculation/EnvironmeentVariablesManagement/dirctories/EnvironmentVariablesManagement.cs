
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class EnvironmentVariablesSourceDirectory
    {
        public static string GetName(IConfiguration config)
        {
             string environmentVariablesSourceDirectoryNameKey =
                CommandLineArgs.GetKey(config, "EnvironmentVariablesSourceDirectoryNameKey");         

            string environmentVariablesSourceDirectoryName = CommandLineArgs.GetByKey(environmentVariablesSourceDirectoryNameKey);

            string environmentVariablesSourceDirectory =
                Path.Combine(ScriptsDirectory.GetName(config), environmentVariablesSourceDirectoryName);

            return environmentVariablesSourceDirectory;
        }        
    }
}