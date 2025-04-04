namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.NotesAndMessages
{
    public class NotesAndMessagesDirectory(
            DirectoriesNameToKeyMap directoriesNameToKeyMap,
            FeatureDirectory featureDirectory
        )
    {
        public string GetPath(string key)
        {
            var directoryName = directoriesNameToKeyMap.GetValue(key);
            var featureDirectoryPath = featureDirectory.GetPath();
            var directoryThatIsGoingToBeOpen = Path.Combine(featureDirectoryPath, directoryName);
            return directoryThatIsGoingToBeOpen;
        }
    }
}