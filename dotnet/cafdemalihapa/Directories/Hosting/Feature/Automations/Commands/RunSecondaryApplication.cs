namespace cafdemalihapa.Directories.Hosting.Feature.Automations.Commands
{
    public class RunSecondaryApplication
    (
        CommandsDirectory commandsDirectory
    )
    {
        public string GetPath()
        {
            var commandsDirectoryPath = commandsDirectory.GetPath();
            var operationsDirectory = Path.Combine(commandsDirectoryPath, "run-secondary-application.ps1");
            return operationsDirectory;
        }
    }
}