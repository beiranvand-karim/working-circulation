namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory
{
    public class FeatureDirectory(
            CommandLineArgs commandLineArgs,
            HostingDirectory hostingDirectory
        )
    {
        public void Create()
        {
            var featureDirectoryPath = GetPath();
            Directory.CreateDirectory(featureDirectoryPath);
        }

        public string GetPath()
        {
            var featureDirectoryNameKey = commandLineArgs.GetKey("FeatureNameKey");
            var featureDirectoryName = CommandLineArgs.GetByKey(featureDirectoryNameKey);
            var hostingDirectoryName = hostingDirectory.GetPath();
            var featureNameDirectoryPath = Path.Combine(hostingDirectoryName, featureDirectoryName);
            return featureNameDirectoryPath;
        }
    }
}