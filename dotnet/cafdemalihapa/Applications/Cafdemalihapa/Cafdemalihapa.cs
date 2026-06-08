using cafdemalihapa.Directories.Hosting.Feature;
using cafdemalihapa.Directories.Hosting.Feature.Automations;
using cafdemalihapa.Directories.Hosting.Feature.Automations.Commands;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.DirectoriesMultitude;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.IdeJetbrains;
using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.Notepad;
using cafdemalihapa.Directories.Hosting.Feature.Automations.Operations;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.PowerShellScripts;
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