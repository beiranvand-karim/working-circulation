using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Helpers.Interfaces;
using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Feature.FrontEndDirectory
{
    public class FrontEndDirectory(
            IDirectoriesNameToKeyMap directoriesNameToKeyMap,
            IFeatureNameDirectory featureNameDirectory,
            ICommandLineArgs commandLineArgs,
            ILogger<FrontEndDirectory> logger,
            IStringHelpers stringHelpers
        ) : IFrontEndDirectory
    {
        private readonly IDirectoriesNameToKeyMap directoriesNameToKeyMap = directoriesNameToKeyMap;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly ILogger<FrontEndDirectory> logger = logger;
        private readonly IStringHelpers stringHelpers = stringHelpers;

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