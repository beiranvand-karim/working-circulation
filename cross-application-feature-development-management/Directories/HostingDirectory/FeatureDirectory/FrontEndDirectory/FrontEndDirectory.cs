using cross_application_feature_development_management.Helpers;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory
{
    public class FrontEndDirectory(
            DirectoriesNameToKeyMap directoriesNameToKeyMap,
            FeatureDirectory featureDirectory,
            CommandLineArgs commandLineArgs,
            ILogger<FrontEndDirectory> logger,
            StringHelpers stringHelpers
        )
    {
        public string GetPath(string key)
        {
            var directoryName = directoriesNameToKeyMap.GetValue(key);
            var featureDirectoryPath = featureDirectory.GetPath();
            var directoryThatIsGoingToBeOpen = Path.Combine(featureDirectoryPath, directoryName);

            logger.LogInformation("directory: {directoryThatIsGoingToBeOpen}", directoryThatIsGoingToBeOpen);
            return directoryThatIsGoingToBeOpen;
        }
    }
}