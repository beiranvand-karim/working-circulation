namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.WebLinks
{
    public class WebLinksDirectory
    (
        FeatureDirectory featureDirectory
    )
    {
        public string GetPath()
        {
            var directoryName = "web links";
            var featureDirectoryPath = featureDirectory.GetPath();
            var notesAndMessages = Path.Combine(featureDirectoryPath, directoryName);
            return notesAndMessages;
        }
    }
}