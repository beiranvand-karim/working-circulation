using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Directories.Feature.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Interfaces;
using cross_application_feature_development_management.Names.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management
{
    public class CrossApplicationFeatureDevelopmentManagement(
            ILogger<CrossApplicationFeatureDevelopmentManagement> logger,
            IScriptsDirectory scriptsDirectory,
            ITemplatesDirectory templatesDirectory,
            IFeatureNameDirectory featureNameDirectory,
            IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
            IEnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory,
            IPowerShellScriptsDirectory powerShellScriptsDirectory,
            IBatchScriptsDirectory batchScriptsDirectory,
            ISomething something,
            IEnvironmentVariablesSourceFilesDirectory environmentVariablesSourceFilesDirectory,
            IAutomationsDirectory automationsDirectory,
            ICommandLineArgs commandLineArgs
            )
        : ICrossApplicationFeatureDevelopmentManagement
    {
        private readonly ILogger<CrossApplicationFeatureDevelopmentManagement> logger = logger;
        private readonly IScriptsDirectory scriptsDirectory = scriptsDirectory;
        private readonly ITemplatesDirectory templatesDirectory = templatesDirectory;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory = environmentVariablesFilesDirectory;
        private readonly IEnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory = environmentVariablesSourceDirectory;
        private readonly IPowerShellScriptsDirectory powerShellScriptsDirectory = powerShellScriptsDirectory;
        private readonly IBatchScriptsDirectory batchScriptsDirectory = batchScriptsDirectory;
        private readonly ISomething something = something;
        private readonly IEnvironmentVariablesSourceFilesDirectory environmentVariablesSourceFilesDirectory = environmentVariablesSourceFilesDirectory;
        private readonly IAutomationsDirectory automationsDirectory = automationsDirectory;

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
                var templateSourceDirectory =
                    Path.Combine(
                        scriptsDirectory.GetName(),
                        templatesDirectory.GetName()
                    );

                featureNameDirectory.CreateSelf();

                automationsDirectory.Create();

                Directory.CreateDirectory(environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory());
                var destinationDirectory = environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory();

                Dictionary<string, string> environmentVariablesSourceDictionary;
                
                if(IsFormatJson())
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
                

                environmentVariablesSourceFilesDirectory.Populate(destinationDirectory, templateSourceDirectory, environmentVariablesSourceDictionary);

                powerShellScriptsDirectory.CopyContentToFeatureNameDirectory();
                powerShellScriptsDirectory.ReplaceFileNamesWithPaths();

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