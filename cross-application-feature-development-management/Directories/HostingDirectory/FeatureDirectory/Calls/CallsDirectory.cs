namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Calls
{
    public class CallsDirectory
    (
        FeatureDirectory featureDirectory
    )
    {
        public string GetPath()
        {
            var directoryName = "calls";
            var featureDirectoryPath = featureDirectory.GetPath();
            var notesAndMessages = Path.Combine(featureDirectoryPath, directoryName);
            return notesAndMessages;
        }
    }
}