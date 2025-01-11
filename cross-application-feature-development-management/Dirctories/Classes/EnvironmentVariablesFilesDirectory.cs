using cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Classes
{
    public class EnvironmentVariablesFilesDirectory(
            IScriptsDirectory scriptsDirectory,
            IFeatureNameDirectory featureNameDirectory,
            ICommandLineArgs commandLineArgs,
            ITargetDirectory targetDirectory,
            IDirectories directories,
            IAutomationsDirectory automationsDirectory
        ) : IEnvironmentVariablesFilesDirectory
    {
        private readonly IScriptsDirectory scriptsDirectory = scriptsDirectory;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly ITargetDirectory targetDirectory = targetDirectory;
        private readonly IDirectories directories = directories;
        private readonly IAutomationsDirectory automationsDirectory = automationsDirectory;

        public void CopyContentToFeatureNameDicrectory()
        {
            var sourceDirectory = CreatePathToSelfInScriptsDirectory();
            var destinationDirectory = CreatePathToSelfInFeatureNameDirectory();

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public void CopyContentToTargetDicrectory()
        {
            var sourceDirectory = CreatePathToSelfInScriptsDirectory();
            var destinationDirectory = CreatePathToSelfInTargetDirectory();

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public string CreatePathToSelfInScriptsDirectory()
        {
            var scriptsDirectoryName = scriptsDirectory.GetName();
            var environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public string CreatePathToSelfInFeatureNameDirectory()
        {
            var destinationDirectory = automationsDirectory.GetPath();
            var environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public string CreatePathToSelfInTargetDirectory()
        {
            var destinationDirectory = targetDirectory.CreatePathToSelf();
            var environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public string GetName()
        {
            var destinationDirectoryNameKey =
                commandLineArgs.GetKey("DestinationDirectoryNameKey");

            var destinationDirectoryName = commandLineArgs.GetByKey(destinationDirectoryNameKey);
            return destinationDirectoryName;
        }
    }
}