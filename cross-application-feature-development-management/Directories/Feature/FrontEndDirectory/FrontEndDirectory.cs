using cross_application_feature_development_management.Helpers;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Feature.FrontEndDirectory
{
    public class FrontEndDirectory(
            DirectoriesNameToKeyMap directoriesNameToKeyMap,
            FeatureNameDirectory featureNameDirectory,
            CommandLineArgs commandLineArgs,
            ILogger<FrontEndDirectory> logger,
            StringHelpers stringHelpers
        )
    {
        public string GetPath(string key)
        {
            var directoryName = directoriesNameToKeyMap.GetValue(key);
            var featureNameDirectoryPath = featureNameDirectory.GetPath();
            var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);

            logger.LogInformation("directory: {directoryThatIsGoingToBeOpen}", directoryThatIsGoingToBeOpen);
            return directoryThatIsGoingToBeOpen;
        }
    }
}