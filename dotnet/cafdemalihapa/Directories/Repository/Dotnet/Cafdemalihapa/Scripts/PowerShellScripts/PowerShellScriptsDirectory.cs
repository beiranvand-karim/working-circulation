using cafdemalihapa.Directories.Hosting.Feature.Automations.Commands;

namespace cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.PowerShellScripts
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
