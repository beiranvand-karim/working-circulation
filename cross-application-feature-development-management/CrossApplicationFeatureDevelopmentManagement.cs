using cross_application_feature_development_management.Applications.Cafdem;
using cross_application_feature_development_management.Directories;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.CommandsDirectory;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.OperationsDirectory;
using cross_application_feature_development_management.Directories.Scripts;
using cross_application_feature_development_management.Directories.Scripts.EnvironmentVariablesSource;
using cross_application_feature_development_management.Names;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management
{
    public class CrossApplicationFeatureDevelopmentManagement(
        ILogger<CrossApplicationFeatureDevelopmentManagement> logger,
        FeatureNameDirectory featureNameDirectory,
        EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
        EnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory,
        PowerShellScriptsDirectory powerShellScriptsDirectory,
        BatchScriptsDirectory batchScriptsDirectory,
        Something something,
        EnvironmentVariablesSourceFilesDirectory environmentVariablesSourceFilesDirectory,
        AutomationsDirectory automationsDirectory,
        OperationsDirectory operationsDirectory,
        CommandsDirectory commandsDirectory,
        CafdemTerminalCapturement cafdemTerminalCapturement
    )
    {
        public void Run()
        {
            try
            {
                featureNameDirectory.CreateSelf();

                automationsDirectory.Create();

                Directory.CreateDirectory(environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory());
                var destinationDirectory = environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory();

                Dictionary<string, string> environmentVariablesSourceDictionary;

                if (cafdemTerminalCapturement.IsFormatJson())
                {

                    if (cafdemTerminalCapturement.IsFilementSplit())
                    {
                        environmentVariablesSourceDictionary = something.PairUpEnvironmentVariablesSeparationFilement();
                    }
                    else
                    {
                        environmentVariablesSourceDictionary =
                            something.GetAllEnvironmentVariablesAndValuesFromSourceJsonFile<EnvironmentVariables>(
                                environmentVariablesSourceDirectory.GetName()
                            );
                    }
                }
                else
                {
                    environmentVariablesSourceDictionary =
                        something.GetAllEnvironmentVariablesAndValuesFromSourceFile(
                            environmentVariablesSourceDirectory.GetName()
                        );
                }

                environmentVariablesSourceFilesDirectory.Populate(destinationDirectory, environmentVariablesSourceDictionary);

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