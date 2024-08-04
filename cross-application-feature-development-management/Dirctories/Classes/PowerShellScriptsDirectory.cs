using cross_application_feature_development_management.Dirctories.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Classes
{
    public class PowerShellScriptsDirectory(
        IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
        ITargetDirectory targetDirectory,
        IScriptsDirectory scriptsDirectory,
        IFeatureNameDirectory featureNameDirectory,
        IDirectories directories
        ) : IPowerShellScriptsDirectory
    {
        private readonly IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory = environmentVariablesFilesDirectory;
        private readonly ITargetDirectory targetDirectory = targetDirectory;
        private readonly IScriptsDirectory scriptsDirectory = scriptsDirectory;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly IDirectories directories = directories;

        public void ReplaceFileNamesWithPaths()
        {
            string direcName = "powershell-scripts";
            string pathInTarget = ConstructPathToSelfInFeatureNameDirectory(direcName);
            string giversPath = environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory();
            foreach (string filePath in Directory.EnumerateFiles(pathInTarget))
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string giverFileName = $"""{fileName}.env""";
                string giverPath = Path.Combine(giversPath, giverFileName);
                directories.ReplaceFileNameWithPath(filePath, giverPath);
            }
        }

        public void CopyContentToFeatureNameDicrectory()
        {
            string direcName = "powershell-scripts";
            Directory.CreateDirectory(ConstructPathToSelfInFeatureNameDirectory(direcName));
            string sourceDirectory = ConstructPathToSelfInScriptsDirectory(direcName);
            string destinationDirectory = ConstructPathToSelfInFeatureNameDirectory(direcName);

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public void CopyContentToTargetDicrectory()
        {
            string direcName = "powershell-scripts";
            Directory.CreateDirectory(ConstructPathToSelfInTargetDirectory(direcName));
            string sourceDirectory = ConstructPathToSelfInScriptsDirectory(direcName);
            string destinationDirectory = ConstructPathToSelfInTargetDirectory(direcName);

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public string ConstructPathToSelfInScriptsDirectory(string direcName)
        {
            string scriptsDirectoryName = scriptsDirectory.GetName();
            string environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, direcName);
            return environmentVariablesFilesDirectory;
        }

        public string ConstructPathToSelfInFeatureNameDirectory(string direcName)
        {
            string destinationDirectory = featureNameDirectory.GetPath();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, direcName);
            return environmentVariablesFilesDirectory;
        }

        public string ConstructPathToSelfInTargetDirectory(string direcName)
        {
            string destinationDirectory = targetDirectory.CreatePathToSelf();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, direcName);
            return environmentVariablesFilesDirectory;
        }

        public string ConstructPathToSelfInScriptsDirectory()
        {
            string scriptsDirectoryName = scriptsDirectory.GetName();
            string environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, "powershell-scripts");
            return environmentVariablesFilesDirectory;
        }

        public string ConstructPathToSelfInTargetDirectory()
        {
            string destinationDirectory = targetDirectory.CreatePathToSelf();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "powershell-scripts");
            return environmentVariablesFilesDirectory;
        }
    }
}
