using Microsoft.Extensions.Logging;
using notepad_plus_plus_file_management.Dirctories.Interfaces;
using notepad_plus_plus_file_management.Helpers.Interfaces;
using notepad_plus_plus_file_management.Interfaces;

namespace notepad_plus_plus_file_management.Dirctories.Classes
{
    public class FeatureNameDirectory(
            ICommandLineArgs commandLineArgs,
            IHostingDirectory hostingDirectory,
            ILogger<FeatureNameDirectory> logger,
            IStringHelpers stringHelpers
        ) : IFeatureNameDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IHostingDirectory hostingDirectory = hostingDirectory;
        private readonly ILogger<FeatureNameDirectory> logger = logger;
        private readonly IStringHelpers stringHelpers = stringHelpers;

        public void CreateSelf()
        {
            string featureNameDirectoryPath = GetPath();
            Directory.CreateDirectory(featureNameDirectoryPath);
        }

        public string GetPath()
        {
            string featureNameDirectoryNameKey = commandLineArgs.GetKey("FeatureNameKey");
            string featureNameDirectoryName = commandLineArgs.GetByKey(featureNameDirectoryNameKey);
            string hostingDirectoryName = hostingDirectory.GetName();
            string featureNameDirectoryPath = Path.Combine(hostingDirectoryName, featureNameDirectoryName);
            logger.LogInformation("feature name directory path: {featureNameDirectoryPath}", featureNameDirectoryPath);
            return featureNameDirectoryPath;
        }
    }
}