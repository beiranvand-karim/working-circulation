using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Helpers.Interfaces;
using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Dirctories.Feature.FrontEndDirectory.FrontEndHostDirectory
{
    public class FrontEndHostDirectory(
            IDirectoriesNameToKeyMap directoriesNameToKeyMap,
            IFeatureNameDirectory featureNameDirectory,
            ICommandLineArgs commandLineArgs,
            ILogger<FrontEndHostDirectory> logger,
            IStringHelpers stringHelpers
        ) : IFrontEndHostDirectory
    {
        private readonly IDirectoriesNameToKeyMap directoriesNameToKeyMap = directoriesNameToKeyMap;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly ILogger<FrontEndHostDirectory> logger = logger;
        private readonly IStringHelpers stringHelpers = stringHelpers;

        public string GetPath(string key)
        {
            var directoryName = directoriesNameToKeyMap.GetValue(key);
            var featureNameDirectoryPath = featureNameDirectory.GetPath();
            var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);

            var hostApplicationName = commandLineArgs.GetByKey("--host-application-name");

            var x = $"{directoryName}.{hostApplicationName}";

            var directoryThatIsGoingToBeOpen2 = Path.Combine(directoryThatIsGoingToBeOpen, x);
            logger.LogInformation("front end host directory: {FrontEndHostDirectory}", directoryThatIsGoingToBeOpen2);
            return directoryThatIsGoingToBeOpen2;
        }
    }
}