using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class TemplatesDirectory
    {
        public static string GetName(IConfiguration config)
        {
            string templatesDirectoryNameKey =
                CommandLineArgs.GetKey(config, "TemplatesDirectoryNameKey");

            string templatesDirectoryName = CommandLineArgs.GetByKey(templatesDirectoryNameKey);
            return templatesDirectoryName;
        }       
    }
}