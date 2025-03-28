namespace cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.OperationsDirectory
{
    public class OperationsDirectory(
        AutomationsDirectory automationsDirectory,
        Directories directories
        )
    {
        public void Create()
        {
            var path = GetPath();
            Directory.CreateDirectory(path);
        }
        public string GetPath()
        {
            var directory = automationsDirectory.GetPath();
            var operationsDirectory = Path.Combine(directory, "operations");
            return operationsDirectory;
        }

        public void ReplaceFileNamesWithPaths(string giversPath)
        {
            var pathToTarget = GetPath();
            foreach (var filePath in Directory.EnumerateFiles(pathToTarget))
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var giverFileName = $"{fileName}.ps1";
                var giverPath = Path.Combine(giversPath, giverFileName);
                directories.ReplaceFileNameWithPath(filePath, giverPath);
            }
        }
    }
}