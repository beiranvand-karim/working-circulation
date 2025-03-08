using cross_application_feature_development_management.Helpers;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndHostDirectory
{
    public class FrontEndHostDirectory(
            DirectoriesNameToKeyMap directoriesNameToKeyMap,
            FeatureNameDirectory featureNameDirectory,
            CommandLineArgs commandLineArgs,
            ILogger<FrontEndHostDirectory> logger,
            StringHelpers stringHelpers
        )
    {
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