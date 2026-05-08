using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Classes
{
    public class FeatureNameDirectory(
            ICommandLineArgs commandLineArgs,
            IHostingDirectory hostingDirectory
        ) : IFeatureNameDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IHostingDirectory hostingDirectory = hostingDirectory;

        public void CreateSelf()
        {
            var featureNameDirectoryPath = GetPath();
            Directory.CreateDirectory(featureNameDirectoryPath);
        }

        public string GetPath()
        {
            var featureNameDirectoryNameKey = commandLineArgs.GetKey("FeatureNameKey");
            var featureNameDirectoryName = commandLineArgs.GetByKey(featureNameDirectoryNameKey);
            var hostingDirectoryName = hostingDirectory.GetName();
            var featureNameDirectoryPath = Path.Combine(hostingDirectoryName, featureNameDirectoryName);
            return featureNameDirectoryPath;
        }
    }
}