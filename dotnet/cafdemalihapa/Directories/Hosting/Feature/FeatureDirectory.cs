namespace cafdemalihapa.Directories.Hosting.Feature
{
    public static class FeatureDirectory
    {
        public static void Create()
        {
            var featureDirectoryPath = GetPath();
            Directory.CreateDirectory(featureDirectoryPath);
        }

        public static string GetPath()
        {
            var featureName = CommandLineArgs.GetByKey("--feature-name");
            var hostingDirectoryName = HostingDirectory.GetPath();
            var featureDirectoryPath = Path.Combine(hostingDirectoryName, featureName);
            return featureDirectoryPath;
        }
    }
}