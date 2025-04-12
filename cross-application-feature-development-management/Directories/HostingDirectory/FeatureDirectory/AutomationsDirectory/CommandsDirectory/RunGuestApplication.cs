namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory
{
    public class RunGuestApplication
    (
        CommandsDirectory commandsDirectory
    )
    {
        public string GetPath()
        {
            var commandsDirectoryPath = commandsDirectory.GetPath();
            var operationsDirectory = Path.Combine(commandsDirectoryPath, "run-guest-application.ps1");
            return operationsDirectory;
        }
    }
}