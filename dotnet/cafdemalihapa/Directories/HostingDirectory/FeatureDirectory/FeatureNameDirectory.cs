namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory
{
    public class FeatureDirectory(
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
            var featureName = CommandLineArgs.GetByKey("--feature-name");
            var hostingDirectoryName = hostingDirectory.GetPath();
            var featureDirectoryPath = Path.Combine(hostingDirectoryName, featureName);
            return featureDirectoryPath;
        }
    }
}