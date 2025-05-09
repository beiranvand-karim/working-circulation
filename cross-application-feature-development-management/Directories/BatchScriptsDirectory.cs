using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.OperationsDirectory;

namespace cross_application_feature_development_management.Directories
{
    public class BatchScriptsDirectory(
        PowerShellScriptsDirectory powerShellScriptsDirectory,
        FeatureNameDirectory featureNameDirectory,
        TargetDirectory targetDirectory,
        ScriptsDirectory scriptsDirectory,
        Directories directories,
        AutomationsDirectory automationsDirectory,
        OperationsDirectory operationsDirectory
        )
    {
        public void CopyContentToDirectory(string destinationDirectory)
        {
            var sourceDirectory = GetPath();
            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public string GetPath()
        {
            var scriptsDirectoryName = scriptsDirectory.GetName();
            var batchScriptsDirectoryPath = Path.Combine(scriptsDirectoryName, "batch-scripts");
            return batchScriptsDirectoryPath;
        }
    }
}