using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;

namespace cross_application_feature_development_management.Directories
{
    public class EnvironmentVariablesFilesDirectory(
            ScriptsDirectory scriptsDirectory,
            FeatureNameDirectory featureNameDirectory,
            CommandLineArgs commandLineArgs,
            TargetDirectory targetDirectory,
            Directories directories,
            AutomationsDirectory automationsDirectory
        )
    {
        public void CopyContentToFeatureNameDirectory()
        {
            var sourceDirectory = CreatePathToSelfInScriptsDirectory();
            var destinationDirectory = CreatePathToSelfInFeatureNameDirectory();

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public void CopyContentToTargetDirectory()
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