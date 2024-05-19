

using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class FeatureNameDirectory
    {
         public static void CreateSelf(IConfiguration config)
        {

            string featureNameDirectoryPath = GetPath(config);
            Directory.CreateDirectory(featureNameDirectoryPath);

        }
        public static string GetPath(IConfiguration config)
        {
            string featureNameDirectoryNameKey =  CommandLineArgs.GetKey(config, "FeatureNameKey");
            string featureNameDirectoryName = CommandLineArgs.GetByKey(featureNameDirectoryNameKey);
            string hostingDirectoryName = HostingDirectory.GetName(config);
            string featureNameDirectoryPath = Path.Combine(hostingDirectoryName, featureNameDirectoryName);
            return featureNameDirectoryPath;          
        }     
    }
}