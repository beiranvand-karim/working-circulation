
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class SriptsDirectory
    {
        public static string GetName(IConfiguration config)
        {
            string scriptsDirectoryNameKey = CommandLineArgs.GetKey(config, "ScriptsDirectoryNameKey");
            string scriptsDirectoryName = CommandLineArgs.GetByKey(scriptsDirectoryNameKey);
            return scriptsDirectoryName;
        }        
    }
}