using cross_application_feature_development_management.Combiners.Interfaces;
using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Interfaces;
using cross_application_feature_development_management.Names.Interfaces;

namespace cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.EnvironmentVariablesTemplateFiles
{
    public interface IEnvironmentVariablesSourceFilesDirectory
    {
        public string GetPath();
        public void Populate(string destinationDirectory, string templateSourceDirectory, Dictionary<string, string> environmentVariablesSourceDictionary);
    }

    public class EnvironmentVariablesSourceFilesDirectory(
            ISomethingFeatureNameDirectory somethingFeatureNameDirectory,
            IAddToStartupScript addToStartupScript,
            INotePadPlusPlusOpenAll notePadPlusPlusOpenAll,
            ISomething something,
            IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
            INotePadPlusPlusAllClose notePadPlusPlusAllClose,
            INotepadPlusPlusMultitudeAllOrderReverseActionOpen notepadPlusPlusMultitudeAllOrderReverseActionOpen,
            IdeJetbrainsRiderMultitudePrimaryActionOpen  ideJetbrainsRiderMultitudePrimaryActionOpen,
            IdeJetbrainsRiderMultitudeSecondaryActionOpen ideJetbrainsRiderMultitudeSecondaryActionOpen,
            IdeJetbrainsWebstromMultitudePrimaryActionOpen ideJetbrainsWebstromMultitudePrimaryActionOpen
        ) : IEnvironmentVariablesSourceFilesDirectory
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
            foreach (var templateFile in Directory.EnumerateFiles(templateSourceDirectory))
            {
                var destFileName = Path.GetFileNameWithoutExtension(templateFile);
                var destFile = Path.Combine(destinationDirectory, destFileName);
                using var fs = File.Create(destFile);

                var contentToWrite = destFileName switch
                {
                    "directories" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "startup" => addToStartupScript.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "notepadpp-open-all" => notePadPlusPlusOpenAll.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "notepadplusplus-multitude-all-order-reverse-action-open" =>
                        notepadPlusPlusMultitudeAllOrderReverseActionOpen.PairUpVariablesWithTheirValue(templateFile,
                            environmentVariablesSourceDictionary),
                    "notepadpp-all-close" => notePadPlusPlusAllClose.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-rider-multitude-primary-action-open.env" => ideJetbrainsRiderMultitudePrimaryActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-rider-multitude-secondary-action-open.env" => ideJetbrainsRiderMultitudeSecondaryActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-webstorm-multitude-primary-action-open.env" => ideJetbrainsWebstromMultitudePrimaryActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    _ => something.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                };

                using StreamWriter writer = new(fs);
                foreach (var valueToWrite in contentToWrite.Select(entry => $"{entry.Key}={entry.Value}"))
                {
                    writer.WriteLine(valueToWrite);
                }

            }
        }
    }
}