using cross_application_feature_development_management.Names;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndHostDirectory
{
    public class FrontEndHostDirectory(
            FeatureDirectory featureDirectory,
            ILogger<FrontEndHostDirectory> logger,
            FrontEndDirectory frontEndDirectory,
            HostApplicationName hostApplicationName
        )
    {
        public string GetName()
        {
            var frontEndDirectoryName = frontEndDirectory.GetName();
            var hostApplication = hostApplicationName.GetName();
            var name = $"{frontEndDirectoryName}.{hostApplication}";
            return name;
        }

        public string GetPath()
        {
            var frontEndDirectoryPath = frontEndDirectory.GetPath();
            var name = GetName();

            var frontEndHostDirectoryPath = Path.Combine(frontEndDirectoryPath, name);
            return frontEndHostDirectoryPath;
        }
    }
}