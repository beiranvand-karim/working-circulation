using cross_application_feature_development_management.Interfaces;
using cross_application_feature_development_management.Names.Classses;
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
            ISomethingFeatureNameDirectory somethingFeatureNameDirectory,
            IPowerShellScriptsDirectory powerShellScriptsDirectory,
            IBatchScriptsDicrectory batchScriptsDicrectory,
            ISomething something
            )
        : ICrossApplicationFeatureDevelopmentManagement
    {
        private readonly ILogger<CrossApplicationFeatureDevelopmentManagement> logger = logger;
        private readonly IScriptsDirectory scriptsDirectory = scriptsDirectory;
        private readonly ITemplatesDirectory templatesDirectory = templatesDirectory;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory = environmentVariablesFilesDirectory;
        private readonly IEnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory = environmentVariablesSourceDirectory;
        private readonly ISomethingFeatureNameDirectory somethingFeatureNameDirectory = somethingFeatureNameDirectory;
        private readonly IPowerShellScriptsDirectory powerShellScriptsDirectory = powerShellScriptsDirectory;
        private readonly IBatchScriptsDicrectory batchScriptsDicrectory = batchScriptsDicrectory;
        private readonly ISomething something = something;

        public void Run()
        {
            try
            {
                string templateSourceDirectory =
                    Path.Combine(
                        scriptsDirectory.GetName(),
                        templatesDirectory.GetName()
                    );

                featureNameDirectory.CreateSelf();

                Directory.CreateDirectory(environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory());
                string destinationDirectory = environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory();

                Dictionary<string, string> environmentVariablesSourceDictionary =
                        something.GetAllEnvironmentVariablesAndValuesFromSourceFile(
                            environmentVariablesSourceDirectory.GetName()
                        );

                foreach (string templateFile in Directory.EnumerateFiles(templateSourceDirectory))
                {
                    string destFileName = Path.GetFileNameWithoutExtension(templateFile);
                    string destFile = Path.Combine(destinationDirectory, destFileName);
                    using var fs = File.Create(destFile);

                    Dictionary<string, string> contentToWrite = [];

                    if (templateFile.Contains("directories"))
                    {
                        contentToWrite =
                        somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
                    }
                    else
                    {
                        contentToWrite =
                        Something.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
                    }

                    using StreamWriter writer = new(fs);
                    foreach (KeyValuePair<string, string> entry in contentToWrite)
                    {
                        string valueToWrite = $"""{entry.Key}={entry.Value}""";
                        writer.WriteLine(valueToWrite);
                    }

                }
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