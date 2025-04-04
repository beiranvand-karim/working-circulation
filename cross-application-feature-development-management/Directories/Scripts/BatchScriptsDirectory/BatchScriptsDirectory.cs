namespace cross_application_feature_development_management.Directories.Scripts.BatchScriptsDirectory
{
    public class BatchScriptsDirectory(
        ScriptsDirectory scriptsDirectory,
        Directories directories
        )
    {
        public void CopyContentToDirectory(string destinationDirectory)
        {
            var sourceDirectory = GetPath();
            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public string GetPath()
        {
            var scriptsDirectoryName = scriptsDirectory.GetPath();
            var batchScriptsDirectoryPath = Path.Combine(scriptsDirectoryName, "batch-scripts");
            return batchScriptsDirectoryPath;
        }
    }
}