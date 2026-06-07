using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.OperationsDirectory;
using cafdemalihapa.Directories.Repository.DotnetDirectory.Cafdemalihapa.Scripts.PowerShellScriptsDirectory;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Applications.Cafdemalihapa
{
    public class Cafdemalihapa(
        ILogger<Cafdemalihapa> logger,
        FeatureDirectory featureDirectory,
        EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
        PowerShellScriptsDirectory powerShellScriptsDirectory,
        EnvironmentVariablesSourceFilesDirectory environmentVariablesSourceFilesDirectory,
        AutomationsDirectory automationsDirectory,
        OperationsDirectory operationsDirectory,
        CommandsDirectory commandsDirectory,
        FolderViewConfigurator folderViewConfigurator
    )
    {
        public void Run()
        {
            try
            {
                CreateDirectories();

                environmentVariablesSourceFilesDirectory.Populate();

                powerShellScriptsDirectory.CopyContentToDirectory();
                commandsDirectory.ReplaceFileNamesWithPaths();

                operationsDirectory.ReplaceFileNamesWithPaths();

                folderViewConfigurator.Configure();
            }
            catch (Exception ex)
            {
                logger.LogInformation("Cafdemalihapa: An error occurred while running the application.");
                logger.LogInformation("_________________________________________________");
                logger.LogError(ex, "Cafdemalihapa: An unhandled error occurred while running the application.");
                logger.LogInformation("_________________________________________________");
            }
        }

        public void CreateDirectories()
        {
            featureDirectory.Create();
            automationsDirectory.Create();
            environmentVariablesFilesDirectory.Create();
            commandsDirectory.Create();
            operationsDirectory.Create();
        }
    }
}