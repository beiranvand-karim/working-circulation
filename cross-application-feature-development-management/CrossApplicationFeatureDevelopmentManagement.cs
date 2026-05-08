using cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory.BatchScriptFilesDirectory;
using cross_application_feature_development_management.Dirctories.Interfaces;
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
            IBatchScriptsDicrectory batchScriptsDicrectory,
            ISomething something,
            IBatchScriptFilesDirectory batchScriptFilesDirectory,
            IAutomationsDirectory automationsDirectory
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
        private readonly IBatchScriptsDicrectory batchScriptsDicrectory = batchScriptsDicrectory;
        private readonly ISomething something = something;
        private readonly IBatchScriptFilesDirectory batchScriptFilesDirectory = batchScriptFilesDirectory;
        private readonly IAutomationsDirectory automationsDirectory = automationsDirectory;

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

                var environmentVariablesSourceDictionary =
                        something.GetAllEnvironmentVariablesAndValuesFromSourceFile(
                            environmentVariablesSourceDirectory.GetName()
                        );

                batchScriptFilesDirectory.Populate(destinationDirectory, templateSourceDirectory, environmentVariablesSourceDictionary);

                powerShellScriptsDirectory.CopyContentToFeatureNameDicrectory();
                powerShellScriptsDirectory.ReplaceFileNamesWithPaths();

                batchScriptsDicrectory.CopyContentToFeaureNameDicrectory();
                batchScriptsDicrectory.ReplaceFileNamesWithPaths();
            }
            catch (Exception exception)
            {
                logger.LogError("{exception}", exception.Message);
            }
        }
    }
}