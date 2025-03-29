using cross_application_feature_development_management.Combiners;
using cross_application_feature_development_management.Directories.Scripts;
using cross_application_feature_development_management.Names;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.EnvironmentVariablesTemplateFiles
{
    public class EnvironmentVariablesSourceFilesDirectory(
            SomethingFeatureNameDirectory somethingFeatureNameDirectory,
            AddToStartupScript addToStartupScript,
            NotePadPlusPlusOpenAll notePadPlusPlusOpenAll,
            Something something,
            EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
            NotePadPlusPlusAllClose notePadPlusPlusAllClose,
            NotepadPlusPlusMultitudeAllOrderReverseActionOpen notepadPlusPlusMultitudeAllOrderReverseActionOpen,
            IdeJetbrainsRiderMultitudePrimaryActionOpen ideJetbrainsRiderMultitudePrimaryActionOpen,
            IdeJetbrainsRiderMultitudeSecondaryActionOpen ideJetbrainsRiderMultitudeSecondaryActionOpen,
            IdeJetbrainsWebstormMultitudePrimaryActionOpen ideJetbrainsWebstormMultitudePrimaryActionOpen,
            IdeJetbrainsWebstormMultitudeSecondaryActionOpen ideJetbrainsWebstormMultitudeSecondaryActionOpen,
            IdeJetbrainsWebstormMultitudePrimaryActionShut ideJetbrainsWebstormMultitudePrimaryActionShut,
            IdeJetbrainsWebstormMultitudeSecondaryActionShut ideJetbrainsWebstormMultitudeSecondaryActionShut,
            IdeJetbrainsRiderMultitudePrimaryActionShut ideJetbrainsRiderMultitudePrimaryActionShut,
            IdeJetbrainsRiderMultitudeSecondaryActionShut ideJetbrainsRiderMultitudeSecondaryActionShut,
            TemplatesDirectory templatesDirectory,
            ILogger<EnvironmentVariablesSourceFilesDirectory> logger
        )
    {
        public void Populate(string destinationDirectory, Dictionary<string, string> environmentVariablesSourceDictionary)
        {
            var templateSourceDirectory = templatesDirectory.GetPath();

            foreach (var templateFile in Directory.EnumerateFiles(templateSourceDirectory))
            {
                var destFileName = Path.GetFileName(templateFile);
                var destFile = Path.Combine(destinationDirectory, destFileName);

                var contentToWrite = destFileName switch
                {
                    "directories-multitude-serving-order-reverse-action-open.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-commanding-order-reverse-action-open.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-commanding-order-recto-action-open.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-commanding-order-recto-action-shut.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-serving-order-recto-action-open.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-serving-order-recto-action-shut.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-startup-action-add.env" => addToStartupScript.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-startup-action-open.env" => addToStartupScript.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "notepadplusplus-multitude-all-order-recto-action-open.env" => notePadPlusPlusOpenAll.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "notepadplusplus-multitude-all-order-reverse-action-open.env" =>
                        notepadPlusPlusMultitudeAllOrderReverseActionOpen.PairUpVariablesWithTheirValue(templateFile,
                            environmentVariablesSourceDictionary),
                    "notepadplusplus-multitude-all-order-recto-action-shut.env" => notePadPlusPlusAllClose.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-rider-multitude-primary-action-open.env" => ideJetbrainsRiderMultitudePrimaryActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-rider-multitude-secondary-action-open.env" => ideJetbrainsRiderMultitudeSecondaryActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-webstorm-multitude-primary-action-open.env" => ideJetbrainsWebstormMultitudePrimaryActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-webstorm-multitude-secondary-action-open.env" => ideJetbrainsWebstormMultitudeSecondaryActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-webstorm-multitude-primary-action-shut.env" => ideJetbrainsWebstormMultitudePrimaryActionShut.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-webstorm-multitude-secondary-action-shut.env" => ideJetbrainsWebstormMultitudeSecondaryActionShut.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-rider-multitude-primary-action-shut.env" => ideJetbrainsRiderMultitudePrimaryActionShut.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "ide-jetbrains-rider-multitude-secondary-action-shut.env" => ideJetbrainsRiderMultitudeSecondaryActionShut.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    _ => Something.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                };

                using var fs = File.Create(destFile);
                using StreamWriter writer = new(fs);
                foreach (var valueToWrite in contentToWrite.Select(entry => $"{entry.Key}={entry.Value}"))
                {
                    writer.WriteLine(valueToWrite);
                }
            }
        }
    }
}