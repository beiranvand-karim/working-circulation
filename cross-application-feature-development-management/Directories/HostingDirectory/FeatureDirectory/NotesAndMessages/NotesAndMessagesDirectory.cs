namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.NotesAndMessages
{
    public class NotesAndMessagesDirectory(
            FeatureDirectory featureDirectory
        )
    {
        public string GetPath()
        {
            var directoryName = "notes and messages";
            var featureDirectoryPath = featureDirectory.GetPath();
            var notesAndMessages = Path.Combine(featureDirectoryPath, directoryName);
            return notesAndMessages;
        }
    }
}