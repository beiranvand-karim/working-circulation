using cross_application_feature_development_management.Combiners;
using cross_application_feature_development_management.Names;

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
            TemplatesDirectory templatesDirectory
        )
    {
        public void Populate(string destinationDirectory, Dictionary<string, string> environmentVariablesSourceDictionary)
        {
            var templateSourceDirectory = templatesDirectory.GetPath();

            foreach (var templateFile in Directory.EnumerateFiles(templateSourceDirectory))
            {
                var destFileName = Path.GetFileNameWithoutExtension(templateFile);
                var destFile = Path.Combine(destinationDirectory, destFileName);
                using var fs = File.Create(destFile);

                var contentToWrite = destFileName switch
                {
                    "directories-include-nothing-order-reverse-action-open.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-inclusive-order-reverse-open.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-multitude-all-action-close.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-open-inclusive.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-open.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "directories-startup-open.env" => somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "startup-add-to.env" => addToStartupScript.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "startup-open-directory.env" => addToStartupScript.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "notepadpp-open-all.env" => notePadPlusPlusOpenAll.PairUpVariablesWithTheirValue(templateFile,
                        environmentVariablesSourceDictionary),
                    "notepadplusplus-multitude-all-order-reverse-action-open.env" =>
                        notepadPlusPlusMultitudeAllOrderReverseActionOpen.PairUpVariablesWithTheirValue(templateFile,
                            environmentVariablesSourceDictionary),
                    "notepadpp-all-close.env" => notePadPlusPlusAllClose.PairUpVariablesWithTheirValue(templateFile,
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

                using StreamWriter writer = new(fs);
                foreach (var valueToWrite in contentToWrite.Select(entry => $"{entry.Key}={entry.Value}"))
                {
                    writer.WriteLine(valueToWrite);
                }
            }
        }
    }
}