using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;

namespace cross_application_feature_development_management.Directories
{
    public class EnvironmentVariablesFilesDirectory(
            ScriptsDirectory scriptsDirectory,
            FeatureNameDirectory featureNameDirectory,
            CommandLineArgs commandLineArgs,
            Directories directories,
            AutomationsDirectory automationsDirectory
        )
    {
        public string CreatePathToSelfInFeatureNameDirectory()
        {
            var destinationDirectory = automationsDirectory.GetPath();
            var environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }
    }
}