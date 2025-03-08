using cross_application_feature_development_management.Helpers;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndGuestDirectory
{
    public class FrontEndGuestDirectory(
        DirectoriesNameToKeyMap directoriesNameToKeyMap,
        FeatureNameDirectory featureNameDirectory,
        CommandLineArgs commandLineArgs,
        ILogger<FrontEndGuestDirectory> logger,
        StringHelpers stringHelpers
        )
    {
        public string GetPath(string key)
        {
            var directoryName = directoriesNameToKeyMap.GetValue(key);
            var featureNameDirectoryPath = featureNameDirectory.GetPath();
            var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);

            var guestApplicationName = commandLineArgs.GetByKey("--guest-application-name");

            var x = $"{directoryName}.{guestApplicationName}";

            var directoryThatIsGoingToBeOpen2 = Path.Combine(directoryThatIsGoingToBeOpen, x);
            logger.LogInformation("front end guest directory: {FrontEndGuestDirectory}", directoryThatIsGoingToBeOpen2);
            return directoryThatIsGoingToBeOpen2;
        }
    }
}