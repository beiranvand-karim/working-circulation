using cross_application_feature_development_management.Combiners.Interfaces;
using cross_application_feature_development_management.Dirctories.Feature.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Names.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory.BatchScriptFilesDirectory
{
    public interface IBatchScriptFilesDirectory
    {
        public string GetPath();
        public void Populate(string destinationDirectory, string templateSourceDirectory, Dictionary<string, string> environmentVariablesSourceDictionary);
    }

    public class BatchScriptFilesDirectory(
            ISomethingFeatureNameDirectory somethingFeatureNameDirectory,
            IAddToStartupScript addToStartupScript,
            INotePadPlusPlusOpenAll notePadPlusPlusOpenAll,
            ISomething something,
            IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
            INotePadPlusPlusAllClose notePadPlusPlusAllClose,
            INotepadPlusPlusMultitudeAllOrderReverseActionOpen notepadPlusPlusMultitudeAllOrderReverseActionOpen
        ) : IBatchScriptFilesDirectory
    {
        private readonly ISomethingFeatureNameDirectory somethingFeatureNameDirectory = somethingFeatureNameDirectory;
        private readonly IAddToStartupScript addToStartupScript = addToStartupScript;
        private readonly INotePadPlusPlusOpenAll notePadPlusPlusOpenAll = notePadPlusPlusOpenAll;
        private readonly IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory = environmentVariablesFilesDirectory;
        private readonly INotePadPlusPlusAllClose notePadPlusPlusAllClose = notePadPlusPlusAllClose;
        private readonly INotepadPlusPlusMultitudeAllOrderReverseActionOpen notepadPlusPlusMultitudeAllOrderReverseActionOpen = notepadPlusPlusMultitudeAllOrderReverseActionOpen;

        public string GetPath()
        {
            throw new NotImplementedException();
        }

        public void Populate(string destinationDirectory, string templateSourceDirectory, Dictionary<string, string> environmentVariablesSourceDictionary)
        {
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
                else if (templateFile.Contains("notepadplusplus-multitude-all-order-reverse-action-open"))
                {
                    contentToWrite =
                    notepadPlusPlusMultitudeAllOrderReverseActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
                }
                else if (templateFile.Contains("notepadpp-all-close"))
                {
                    contentToWrite =
                    notePadPlusPlusAllClose.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
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
        }
    }
}