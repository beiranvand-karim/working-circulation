using cross_application_feature_development_management.Directories;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.OperationsDirectory;
using cross_application_feature_development_management.Names;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management
{
    public class CrossApplicationFeatureDevelopmentManagement(
            ILogger<CrossApplicationFeatureDevelopmentManagement> logger,
            ScriptsDirectory scriptsDirectory,
            TemplatesDirectory templatesDirectory,
            FeatureNameDirectory featureNameDirectory,
            EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
            EnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory,
            PowerShellScriptsDirectory powerShellScriptsDirectory,
            BatchScriptsDirectory batchScriptsDirectory,
            Something something,
            EnvironmentVariablesSourceFilesDirectory environmentVariablesSourceFilesDirectory,
            AutomationsDirectory automationsDirectory,
            CommandLineArgs commandLineArgs,
            OperationsDirectory operationsDirectory,
            AloneDirectory aloneDirectory
            )
    {
        private string GetFormat()
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