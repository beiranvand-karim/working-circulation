using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.OperationsDirectory;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts.PowerShellScriptsDirectory;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Applications.Cafdem
{
    public class Cafdemalihapa(
        ILogger<Cafdemalihapa> logger,
        FeatureDirectory featureDirectory,
        EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
        PowerShellScriptsDirectory powerShellScriptsDirectory,
        EnvironmentVariablesSourceFilesDirectory environmentVariablesSourceFilesDirectory,
        AutomationsDirectory automationsDirectory,
        OperationsDirectory operationsDirectory,
        CommandsDirectory commandsDirectory
    )
    {
        public void Run()
        {
            try
            {
                featureDirectory.Create();

                automationsDirectory.Create();

                environmentVariablesFilesDirectory.Create();
                var environmentVariablesFilesDirectoryPath = environmentVariablesFilesDirectory.GetPath();
                var environmentVariablesSourceDictionary = environmentVariablesFilesDirectory.PairUp();

                environmentVariablesSourceFilesDirectory.Populate(environmentVariablesFilesDirectoryPath, environmentVariablesSourceDictionary);

                commandsDirectory.Create();
                var commandsDirectoryPath = commandsDirectory.GetPath();
                powerShellScriptsDirectory.CopyContentToDirectory(commandsDirectoryPath);
                commandsDirectory.ReplaceFileNamesWithPaths(environmentVariablesSourceDictionary);

                operationsDirectory.Create();
                var operationsDirectoryPath = operationsDirectory.GetPath();
                operationsDirectory.ReplaceFileNamesWithPaths(commandsDirectoryPath);
            }
            catch (Exception ex)
            {
                logger.LogInformation("Cafdemalihapa: An error occurred while running the application.");
                logger.LogInformation("_________________________________________________");
                logger.LogError(ex.ToString());
                logger.LogInformation("_________________________________________________");
            }
        }
    }
}