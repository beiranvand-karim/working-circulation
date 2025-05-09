using cross_application_feature_development_management.Helpers;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndHostDirectory
{
    public class FrontEndHostDirectory(
            DirectoriesNameToKeyMap directoriesNameToKeyMap,
            FeatureDirectory featureDirectory,
            CommandLineArgs commandLineArgs,
            ILogger<FrontEndHostDirectory> logger,
            StringHelpers stringHelpers
        )
    {
        public string GetPath(string key)
        {
            var directoryName = directoriesNameToKeyMap.GetValue(key);
            var featureDirectoryPath = featureDirectory.GetPath();
            var directoryThatIsGoingToBeOpen = Path.Combine(featureDirectoryPath, directoryName);

            var hostApplicationName = CommandLineArgs.GetByKey("--host-application-name");

            var x = $"{directoryName}.{hostApplicationName}";

            var directoryThatIsGoingToBeOpen2 = Path.Combine(directoryThatIsGoingToBeOpen, x);
            logger.LogInformation("front end host directory: {FrontEndHostDirectory}", directoryThatIsGoingToBeOpen2);
            return directoryThatIsGoingToBeOpen2;
        }
    }
}