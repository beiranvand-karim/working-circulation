using notepad_plus_plus_file_management.Combiners.Interfaces;
using notepad_plus_plus_file_management.Dirctories.Interfaces;

namespace notepad_plus_plus_file_management.Dirctories.Classes
{
    public class NotesAndMessagesDirectory(
                IDirectoriesNameToKeyMap directoriesNameToKeyMap,
                IFeatureNameDirectory featureNameDirectory
        ) : INotesAndMessagesDirectory
    {
        private readonly IDirectoriesNameToKeyMap directoriesNameToKeyMap = directoriesNameToKeyMap;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;

        public string GetPath(string key)
        {
            var directoryName = this.directoriesNameToKeyMap.GetValue(key);
            var featureNameDirectoryPath = this.featureNameDirectory.GetPath();
            var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);
            return directoryThatIsGoingToBeOpen;
        }
    }
}