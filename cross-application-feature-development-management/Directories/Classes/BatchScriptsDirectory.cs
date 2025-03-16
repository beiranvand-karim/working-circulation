using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.OperationsDirectory;
using cross_application_feature_development_management.Directories.Interfaces;

namespace cross_application_feature_development_management.Directories.Classes
{
    public class BatchScriptsDirectory(
        IPowerShellScriptsDirectory powerShellScriptsDirectory,
        IFeatureNameDirectory featureNameDirectory,
        ITargetDirectory targetDirectory,
        IScriptsDirectory scriptsDirectory,
        IDirectories directories,
        IAutomationsDirectory automationsDirectory,
        IOperationsDirectory operationsDirectory
        ) : IBatchScriptsDirectory
    {
        private readonly IPowerShellScriptsDirectory powerShellScriptsDirectory = powerShellScriptsDirectory;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly ITargetDirectory targetDirectory = targetDirectory;
        private readonly IScriptsDirectory scriptsDirectory = scriptsDirectory;
        private readonly IDirectories directories = directories;
        private readonly IAutomationsDirectory automationsDirectory = automationsDirectory;
        private readonly IOperationsDirectory operationsDirectory = operationsDirectory;

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