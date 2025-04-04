using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Scripts.PowerShellScriptsDirectory
{
    public class PowerShellScriptsDirectory(
        ScriptsDirectory scriptsDirectory,
        Directories directories,
        ILogger<PowerShellScriptsDirectory> logger
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
