namespace cafdemalihapa.Directories.Repository.Cafdem.Scripts.PowerShellScriptsDirectory
{
    public class PowerShellScriptsDirectory
    (
        ScriptsDirectory scriptsDirectory,
        Directories directories
    )
    {
        const string directoryNameInSourceCode = "powershell-scripts";

        public void CopyContentToDirectory(string destinationDirectory)
        {
            var sourceDirectory = GetPath();
            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public string GetPath()
        {
            var scriptsDirectoryName = scriptsDirectory.GetPath();
            var powerShellDirectoryPathInSourceCode = Path.Combine(scriptsDirectoryName, directoryNameInSourceCode);
            return powerShellDirectoryPathInSourceCode;
        }
    }
}
