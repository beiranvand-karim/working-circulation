using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class HostingDirectory
    {
        public static string GetName(IConfiguration config)
        {
            string hostingDirectoryNameKey = CommandLineArgs.GetKey(config, "HostingDirectoryNameKey");
            string hostingDirectoryName = CommandLineArgs.GetByKey(hostingDirectoryNameKey);
            return hostingDirectoryName;
        }      
    }
}