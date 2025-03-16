using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Helpers.Interfaces;
using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndGuestDirectory
{
    public class FrontEndGuestDirectory(
        IDirectoriesNameToKeyMap directoriesNameToKeyMap,
        IFeatureNameDirectory featureNameDirectory,
        ICommandLineArgs commandLineArgs,
        ILogger<FrontEndGuestDirectory> logger,
        IStringHelpers stringHelpers
        ) : IFrontEndGuestDirectory
    {
        private readonly IDirectoriesNameToKeyMap directoriesNameToKeyMap = directoriesNameToKeyMap;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly ILogger<FrontEndGuestDirectory> logger = logger;
        private readonly IStringHelpers stringHelpers = stringHelpers;

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