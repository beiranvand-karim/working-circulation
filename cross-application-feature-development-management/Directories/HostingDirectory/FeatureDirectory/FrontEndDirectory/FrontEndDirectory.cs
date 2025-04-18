using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory
{
    public class FrontEndDirectory(
            FeatureDirectory featureDirectory,
            ILogger<FrontEndDirectory> logger
        )
    {
        public string GetName()
        {
            return "fend";
        }
        public string GetPath()
        {
            var directoryName = GetName();
            var featureDirectoryPath = featureDirectory.GetPath();
            var frontEndDirectoryPath = Path.Combine(featureDirectoryPath, directoryName);
            return frontEndDirectoryPath;
        }
    }
}