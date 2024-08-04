using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Classes
{
    public class EnvironmentVariablesFilesDirectory(
            IScriptsDirectory scriptsDirectory,
            IFeatureNameDirectory featureNameDirectory,
            ICommandLineArgs commandLineArgs,
            ITargetDirectory targetDirectory,
            IDirectories directories
        ) : IEnvironmentVariablesFilesDirectory
    {
        private readonly IScriptsDirectory scriptsDirectory = scriptsDirectory;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly ITargetDirectory targetDirectory = targetDirectory;
        private readonly IDirectories directories = directories;

        public void CopyContentToFeatureNameDicrectory()
        {
            string sourceDirectory = CreatePathToSelfInScriptsDirectory();
            string destinationDirectory = CreatePathToSelfInFeatureNameDirectory();

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public void CopyContentToTargetDicrectory()
        {
            string sourceDirectory = CreatePathToSelfInScriptsDirectory();
            string destinationDirectory = CreatePathToSelfInTargetDirectory();

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public string CreatePathToSelfInScriptsDirectory()
        {
            string scriptsDirectoryName = scriptsDirectory.GetName();
            string environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public string CreatePathToSelfInFeatureNameDirectory()
        {
            string destinationDirectory = featureNameDirectory.GetPath();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public string CreatePathToSelfInTargetDirectory()
        {
            string destinationDirectory = targetDirectory.CreatePathToSelf();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public string GetName()
        {
            string destinationDirectoryNameKey =
                commandLineArgs.GetKey("DestinationDirectoryNameKey");

            string destinationDirectoryName = commandLineArgs.GetByKey(destinationDirectoryNameKey);
            return destinationDirectoryName;
        }
    }
}