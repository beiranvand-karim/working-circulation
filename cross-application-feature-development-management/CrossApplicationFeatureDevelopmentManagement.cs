using cross_application_feature_development_management.Combiners.Interfaces;
using cross_application_feature_development_management.Dirctories.Feature.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Dirctories.Interfaces;
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
            ISomething something,
            IAddToStartupScript addToStartupScript,
            INotePadPlusPlusOpenAll notePadPlusPlusOpenAll
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
        private readonly IAddToStartupScript addToStartupScript = addToStartupScript;
        private readonly INotePadPlusPlusOpenAll notePadPlusPlusOpenAll = notePadPlusPlusOpenAll;

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
                    else if (templateFile.Contains("startup"))
                    {
                        contentToWrite =
                        addToStartupScript.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
                    }
                    else if (templateFile.Contains("notepadpp-open-all"))
                    {
                        contentToWrite =
                        notePadPlusPlusOpenAll.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
                    }
                    else
                    {
                        contentToWrite =
                        something.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
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