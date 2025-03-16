namespace cross_application_feature_development_management.Directories
{
    public class FeatureNameDirectory(
            CommandLineArgs commandLineArgs,
            HostingDirectory hostingDirectory
        )
    {
        public void CreateSelf()
        {
            var featureNameDirectoryPath = GetPath();
            Directory.CreateDirectory(featureNameDirectoryPath);
        }

        public string GetPath()
        {
            var featureNameDirectoryNameKey = commandLineArgs.GetKey("FeatureNameKey");
            var featureNameDirectoryName = CommandLineArgs.GetByKey(featureNameDirectoryNameKey);
            var hostingDirectoryName = hostingDirectory.GetName();
            var featureNameDirectoryPath = Path.Combine(hostingDirectoryName, featureNameDirectoryName);
            return featureNameDirectoryPath;
        }
    }
}