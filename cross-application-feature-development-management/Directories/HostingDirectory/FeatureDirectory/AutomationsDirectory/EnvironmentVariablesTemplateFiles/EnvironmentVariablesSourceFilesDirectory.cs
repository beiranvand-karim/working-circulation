using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesTemplatesDirectory;
using cross_application_feature_development_management.Names;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles
{
    public class EnvironmentVariablesSourceFilesDirectory(
            DirectoriesMultitudeStartupActionOpen directoriesMultitudeStartupActionOpen,
            NotePadPlusPlusOpenAll notePadPlusPlusOpenAll,
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
            EnvironmentVariablesTemplatesDirectory environmentVariablesTemplatesDirectory,
            DirectoriesMultitudeServingOrderReverseActionOpen directoriesMultitudeServingOrderReverseActionOpen,
            DirectoriesMultitudeCommandingOrderReverseActionOpen directoriesMultitudeCommandingOrderReverseActionOpen,
            DirectoriesMultitudeCommandingOrderRectoActionOpen directoriesMultitudeCommandingOrderRectoActionOpen,
            DirectoriesMultitudeCommandingOrderRectoActionShut directoriesMultitudeCommandingOrderRectoActionShut,
            DirectoriesMultitudeServingOrderRectoActionOpen directoriesMultitudeServingOrderRectoActionOpen,
            DirectoriesMultitudeServingOrderRectoActionShut directoriesMultitudeServingOrderRectoActionShut
        )
    {
        public void Populate(string destinationDirectory, Dictionary<string, string> environmentVariablesSourceDictionary)
        {
            var templateSourceDirectory = environmentVariablesTemplatesDirectory.GetPath();

            foreach (var templateFile in Directory.EnumerateFiles(templateSourceDirectory))
            {
                var destFileName = Path.GetFileName(templateFile);
                var destFile = Path.Combine(destinationDirectory, destFileName);

                var contentToWrite = destFileName switch
                {
                    "directories-multitude-serving-order-reverse-action-open.env" => directoriesMultitudeServingOrderReverseActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-commanding-order-reverse-action-open.env" => directoriesMultitudeCommandingOrderReverseActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-commanding-order-recto-action-open.env" => directoriesMultitudeCommandingOrderRectoActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-commanding-order-recto-action-shut.env" => directoriesMultitudeCommandingOrderRectoActionShut.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-serving-order-recto-action-open.env" => directoriesMultitudeServingOrderRectoActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-serving-order-recto-action-shut.env" => directoriesMultitudeServingOrderRectoActionShut.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-startup-action-add.env" => directoriesMultitudeStartupActionOpen.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-startup-action-open.env" => directoriesMultitudeStartupActionOpen.PairUpVariablesWithTheirValue(templateFile,
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