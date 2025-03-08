namespace cross_application_feature_development_management.Directories
{
    public class NotesAndMessagesDirectory(
            DirectoriesNameToKeyMap directoriesNameToKeyMap,
            FeatureNameDirectory featureNameDirectory
        )
    {
        public string GetPath(string key)
        {
            var directoryName = directoriesNameToKeyMap.GetValue(key);
            var featureNameDirectoryPath = featureNameDirectory.GetPath();
            var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);
            return directoryThatIsGoingToBeOpen;
        }
    }
}