using cross_application_feature_development_management.Directories.Classes;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.OperationsDirectory;
using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Interfaces;
using cross_application_feature_development_management.Names.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management
{
    public class CrossApplicationFeatureDevelopmentManagement(
            ILogger<CrossApplicationFeatureDevelopmentManagement> logger,
            IScriptsDirectory scriptsDirectory,
            TemplatesDirectory templatesDirectory,
            IFeatureNameDirectory featureNameDirectory,
            IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
            IEnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory,
            IPowerShellScriptsDirectory powerShellScriptsDirectory,
            IBatchScriptsDirectory batchScriptsDirectory,
            ISomething something,
            EnvironmentVariablesSourceFilesDirectory environmentVariablesSourceFilesDirectory,
            IAutomationsDirectory automationsDirectory,
            ICommandLineArgs commandLineArgs,
            IOperationsDirectory operationsDirectory,
            AloneDirectory aloneDirectory
            )
        : ICrossApplicationFeatureDevelopmentManagement
    {
        public string GetFormat()
        {
            var format = commandLineArgs.GetByKey("--format");
            return format;
        }

        private bool IsFormatJson()
        {
            return GetFormat() == "json";
        }

        public void Run()
        {
            try
            {
                featureNameDirectory.CreateSelf();

                automationsDirectory.Create();

                Directory.CreateDirectory(environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory());
                var destinationDirectory = environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory();

                Dictionary<string, string> environmentVariablesSourceDictionary;

                if (IsFormatJson())
                {
                    environmentVariablesSourceDictionary =
                        something.GetAllEnvironmentVariablesAndValuesFromSourceJsonFile(
                            environmentVariablesSourceDirectory.GetName()
                        );
                }
                else
                {
                    environmentVariablesSourceDictionary =
                        something.GetAllEnvironmentVariablesAndValuesFromSourceFile(
                            environmentVariablesSourceDirectory.GetName()
                        );
                }


                environmentVariablesSourceFilesDirectory.Populate(destinationDirectory, environmentVariablesSourceDictionary);

                powerShellScriptsDirectory.CopyContentToFeatureNameDirectory();
                powerShellScriptsDirectory.ReplaceFileNamesWithPaths(environmentVariablesSourceDictionary);

                operationsDirectory.Create();
                batchScriptsDirectory.CopyContentToFeatureNameDirectory();
                batchScriptsDirectory.ReplaceFileNamesWithPaths();
            }
            catch (Exception exception)
            {
                logger.LogError("{exception}", exception.Message);
            }
        }
    }
}