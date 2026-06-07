using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory;

namespace cafdemalihapa.Directories.Repository.DotnetDirectory.Cafdemalihapa.Scripts.PowerShellScriptsDirectory
{
    public class PowerShellScriptsDirectory
    (
        ScriptsDirectory scriptsDirectory,
        Directories directories,
        CommandsDirectory commandsDirectory
    )
    {
        const string directoryNameInSourceCode = "powershell-scripts";

        public void CopyContentToDirectory()
        {
            var destinationDirectory = commandsDirectory.GetPath();
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
