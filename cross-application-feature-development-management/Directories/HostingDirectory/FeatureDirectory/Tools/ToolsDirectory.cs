namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Tools
{
    public class ToolsDirectory(
        FeatureDirectory featureDirectory
    )
    {
        public string GetPath()
        {
            var directoryName = "tools";
            var featureDirectoryPath = featureDirectory.GetPath();
            var notesAndMessages = Path.Combine(featureDirectoryPath, directoryName);
            return notesAndMessages;
        }
    }
}