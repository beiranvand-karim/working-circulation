

using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class FeatureNameDirectory
    {
         public static void CreateSelf(IConfiguration config)
        {
            string featureNameDirectoryNameKey =  CommandLineArgs.GetKey(config, "FeatureNameKey");
            string featureNameDirectoryName = CommandLineArgs.GetByKey(featureNameDirectoryNameKey);
            string hostingDirectoryName = Directories.GetHostingDirectoryName(config);
            string featureNameDirectoryPath = Path.Combine(hostingDirectoryName, featureNameDirectoryName);
            Directory.CreateDirectory(featureNameDirectoryPath);

        }       
    }
}