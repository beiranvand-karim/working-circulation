using cross_application_feature_development_management.Dirctories.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Classes
{
    public class BatchScriptsDicrectory(
        IPowerShellScriptsDirectory powerShellScriptsDirectory,
        IFeatureNameDirectory featureNameDirectory,
        ITargetDirectory targetDirectory,
        IScriptsDirectory scriptsDirectory
        ) : IBatchScriptsDicrectory
    {
        private readonly IPowerShellScriptsDirectory powerShellScriptsDirectory = powerShellScriptsDirectory;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly ITargetDirectory targetDirectory = targetDirectory;
        private readonly IScriptsDirectory scriptsDirectory = scriptsDirectory;

        public void ReplaceFileNamesWithPaths()
        {
            string pathToTarget = featureNameDirectory.GetPath();
            string giversPath = powerShellScriptsDirectory.ConstructPathToSelfInFeatureNameDirectory("powershell-scripts");
            foreach (string filePath in Directory.EnumerateFiles(pathToTarget))
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string giverFileName = $"""{fileName}.ps1""";
                string giverPath = Path.Combine(giversPath, giverFileName);
                Directories.ReplaceFileNameWithPath(filePath, giverPath);
            }
        }

        public string ConstructPathToSelfInTargetDirectory(string direcName)
        {
            string destinationDirectory = targetDirectory.CreatePathToSelf();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, direcName);
            return environmentVariablesFilesDirectory;
        }

        public string CreatePathToSelfInFeatureNameDirector()
        {
            string scriptsDirectoryName = scriptsDirectory.GetName();
            string batchScriptsDirectoryPath = Path.Combine(scriptsDirectoryName, "batch-scripts");
            return batchScriptsDirectoryPath;
        }

        public void CopyContentToFeaureNameDicrectory()
        {
            string sourceDirectory = CreatePathToSelfInScriptsDirectory();
            string destinationDirectory = featureNameDirectory.GetPath();

            Directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public void CopyContentToTargetDicrectory()
        {
            string sourceDirectory = CreatePathToSelfInScriptsDirectory();
            string destinationDirectory = targetDirectory.CreatePathToSelf();

            Directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public string CreatePathToSelfInScriptsDirectory()
        {
            string scriptsDirectoryName = scriptsDirectory.GetName();
            string batchScriptsDirectoryPath = Path.Combine(scriptsDirectoryName, "batch-scripts");
            return batchScriptsDirectoryPath;
        }
    }
}