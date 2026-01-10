using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.OperationsDirectory;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.BatchScriptsDirectory;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.PowerShellScriptsDirectory;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Applications.Cafdem
{
    public class CrossApplicationFeatureDevelopmentManagement(
        ILogger<CrossApplicationFeatureDevelopmentManagement> logger,
        FeatureDirectory featureDirectory,
        EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
        PowerShellScriptsDirectory powerShellScriptsDirectory,
        BatchScriptsDirectory batchScriptsDirectory,
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
                batchScriptsDirectory.CopyContentToDirectory(operationsDirectoryPath);
                operationsDirectory.ReplaceFileNamesWithPaths(commandsDirectoryPath);
            }
            catch (Exception exception)
            {
                logger.LogError("CrossApplicationFeatureDevelopmentManagement:{exception}", exception.Message);
            }
        }
    }
}