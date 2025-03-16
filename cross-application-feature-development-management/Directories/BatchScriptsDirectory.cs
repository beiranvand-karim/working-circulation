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
        public void ReplaceFileNamesWithPaths()
        {
            var pathToTarget = operationsDirectory.GetPath();
            var giversPath = powerShellScriptsDirectory.ConstructPathToSelfInFeatureNameDirectory("powershell-scripts");
            foreach (var filePath in Directory.EnumerateFiles(pathToTarget))
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var giverFileName = $"{fileName}.ps1";
                var giverPath = Path.Combine(giversPath, giverFileName);
                directories.ReplaceFileNameWithPath(filePath, giverPath);
            }
        }

        public string ConstructPathToSelfInTargetDirectory(string direcName)
        {
            var destinationDirectory = targetDirectory.CreatePathToSelf();
            var environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, direcName);
            return environmentVariablesFilesDirectory;
        }

        public string CreatePathToSelfInFeatureNameDirector()
        {
            var scriptsDirectoryName = scriptsDirectory.GetName();
            var batchScriptsDirectoryPath = Path.Combine(scriptsDirectoryName, "batch-scripts");
            return batchScriptsDirectoryPath;
        }

        public void CopyContentToFeatureNameDirectory()
        {
            var sourceDirectory = CreatePathToSelfInScriptsDirectory();
            var destinationDirectory = operationsDirectory.GetPath();

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public void CopyContentToTargetDirectory()
        {
            var sourceDirectory = CreatePathToSelfInScriptsDirectory();
            var destinationDirectory = targetDirectory.CreatePathToSelf();

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public string CreatePathToSelfInScriptsDirectory()
        {
            var scriptsDirectoryName = scriptsDirectory.GetName();
            var batchScriptsDirectoryPath = Path.Combine(scriptsDirectoryName, "batch-scripts");
            return batchScriptsDirectoryPath;
        }
    }
}