using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Dirctories
{
    public class FeatureNameDirectory(
            ICommandLineArgs commandLineArgs,
            IHostingDirectory hostingDirectory
        ): IFeatureNameDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IHostingDirectory hostingDirectory = hostingDirectory;

        public void CreateSelf()
        {

            string featureNameDirectoryPath = GetPath();
            Directory.CreateDirectory(featureNameDirectoryPath);

        }

        public string GetPath()
        {
            string featureNameDirectoryNameKey = commandLineArgs.GetKey("FeatureNameKey");
            string featureNameDirectoryName = commandLineArgs.GetByKey(featureNameDirectoryNameKey);
            string hostingDirectoryName = hostingDirectory.GetName();
            string featureNameDirectoryPath = Path.Combine(hostingDirectoryName, featureNameDirectoryName);
            return featureNameDirectoryPath;
        }
    }
}