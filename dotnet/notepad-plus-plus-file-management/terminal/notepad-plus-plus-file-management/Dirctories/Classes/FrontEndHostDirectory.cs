using notepad_plus_plus_file_management.Combiners.Interfaces;
using notepad_plus_plus_file_management.Dirctories.Interfaces;
using notepad_plus_plus_file_management.Interfaces;

namespace notepad_plus_plus_file_management.Dirctories.Classes
{
    public class FrontEndHostDirectory(
            IDirectoriesNameToKeyMap directoriesNameToKeyMap,
            IFeatureNameDirectory featureNameDirectory,
            ICommandLineArgs commandLineArgs
        ) : IFrontEndHostDirectory
    {
        private readonly IDirectoriesNameToKeyMap directoriesNameToKeyMap = directoriesNameToKeyMap;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetPath(string key)
        {
            var directoryName = directoriesNameToKeyMap.GetValue(key);
            var featureNameDirectoryPath = featureNameDirectory.GetPath();
            var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);

            var hostApplicationName = commandLineArgs.GetByKey("--host-application-name");

            var x = string.Format("{0}.{1}", directoryName, hostApplicationName);

            var directoryThatIsGoingToBeOpen2 = Path.Combine(directoryThatIsGoingToBeOpen, x);

            return directoryThatIsGoingToBeOpen2;
        }
    }
}