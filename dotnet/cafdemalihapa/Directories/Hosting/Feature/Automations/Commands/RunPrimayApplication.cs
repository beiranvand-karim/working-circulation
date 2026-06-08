namespace cafdemalihapa.Directories.Hosting.Feature.Automations.Commands
{
    public class RunPrimayApplication(
        CommandsDirectory commandsDirectory
    )
    {
        public string GetPath()
        {
            var commandsDirectoryPath = commandsDirectory.GetPath();
            var operationsDirectory = Path.Combine(commandsDirectoryPath, "run-primary-application.ps1");
            return operationsDirectory;
        }
    }
}