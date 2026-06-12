namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles

open System.IO
open Microsoft.Extensions.Logging
open cafdemwimu.console.Applications
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.DirectoriesMultitude
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.IdeJetbrains
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.IdeMicrosoft
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.Notepad
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesTemplates

type EnvironmentVariablesSourceFilesDirectory
    (
        directoriesMultitudeStartupActionOpen: DirectoriesMultitudeStartupActionOpen,
        notePadPlusPlusOpenAll: NotepadPlusPlusOpenAll,
        notePadPlusPlusAllClose: NotepadPlusPlusAllClose,
        notepadPlusPlusMultitudeAllOrderReverseActionOpen: NotepadPlusPlusMultitudeAllOrderReverseActionOpen,
        ideJetbrainsRiderMultitudePrimaryActionOpen: IdeJetbrainsRiderMultitudePrimaryActionOpen,
        ideJetbrainsRiderMultitudeSecondaryActionOpen: IdeJetbrainsRiderMultitudeSecondaryActionOpen,
        ideJetbrainsRiderMultitudeTertiaryActionOpen: IdeJetbrainsRiderMultitudeTertiaryActionOpen,
        ideJetbrainsWebstormMultitudePrimaryActionOpen: IdeJetbrainsWebstormMultitudePrimaryActionOpen,
        ideJetbrainsWebstormMultitudeSecondaryActionOpen: IdeJetbrainsWebstormMultitudeSecondaryActionOpen,
        ideJetbrainsWebstormMultitudeTertiaryActionOpen: IdeJetbrainsWebstormMultitudeTertiaryActionOpen,
        ideJetbrainsWebstormMultitudePrimaryActionShut: IdeJetbrainsWebstormMultitudePrimaryActionShut,
        ideJetbrainsWebstormMultitudeSecondaryActionShut: IdeJetbrainsWebstormMultitudeSecondaryActionShut,
        ideJetbrainsWebstormMultitudeTertiaryActionShut: IdeJetbrainsWebstormMultitudeTertiaryActionShut,
        ideJetbrainsRiderMultitudePrimaryActionShut: IdeJetbrainsRiderMultitudePrimaryActionShut,
        ideJetbrainsRiderMultitudeSecondaryActionShut: IdeJetbrainsRiderMultitudeSecondaryActionShut,
        ideJetbrainsRiderMultitudeTertiaryActionShut: IdeJetbrainsRiderMultitudeTertiaryActionShut,
        ideMicrosoftVscodeDefaultMultitudePrimaryActionOpen: IdeMicrosoftVscodeDefaultMultitudePrimaryActionOpen,
        ideMicrosoftVscodeDefaultMultitudeSecondaryActionOpen: IdeMicrosoftVscodeDefaultMultitudeSecondaryActionOpen,
        ideMicrosoftVscodeDefaultMultitudeTertiaryActionOpen: IdeMicrosoftVscodeDefaultMultitudeTertiaryActionOpen,
        ideMicrosoftVscodeDefaultMultitudePrimaryActionShut: IdeMicrosoftVscodeDefaultMultitudePrimaryActionShut,
        ideMicrosoftVscodeDefaultMultitudeSecondaryActionShut: IdeMicrosoftVscodeDefaultMultitudeSecondaryActionShut,
        ideMicrosoftVscodeDefaultMultitudeTertiaryActionShut: IdeMicrosoftVscodeDefaultMultitudeTertiaryActionShut,
        ideMicrosoftVscodeInsidersMultitudePrimaryActionOpen: IdeMicrosoftVscodeInsidersMultitudePrimaryActionOpen,
        ideMicrosoftVscodeInsidersMultitudeSecondaryActionOpen: IdeMicrosoftVscodeInsidersMultitudeSecondaryActionOpen,
        ideMicrosoftVscodeInsidersMultitudeTertiaryActionOpen: IdeMicrosoftVscodeInsidersMultitudeTertiaryActionOpen,
        ideMicrosoftVscodeInsidersMultitudePrimaryActionShut: IdeMicrosoftVscodeInsidersMultitudePrimaryActionShut,
        ideMicrosoftVscodeInsidersMultitudeSecondaryActionShut: IdeMicrosoftVscodeInsidersMultitudeSecondaryActionShut,
        ideMicrosoftVscodeInsidersMultitudeTertiaryActionShut: IdeMicrosoftVscodeInsidersMultitudeTertiaryActionShut,
        environmentVariablesTemplatesDirectory: EnvironmentVariablesTemplatesDirectory,
        directoriesMultitudeServingOrderReverseActionOpen: DirectoriesMultitudeServingOrderReverseActionOpen,
        directoriesMultitudeCommandingOrderReverseActionOpen: DirectoriesMultitudeCommandingOrderReverseActionOpen,
        directoriesMultitudeCommandingOrderRectoActionOpen: DirectoriesMultitudeCommandingOrderRectoActionOpen,
        directoriesMultitudeCommandingOrderRectoActionShut: DirectoriesMultitudeCommandingOrderRectoActionShut,
        directoriesMultitudeServingOrderRectoActionOpen: DirectoriesMultitudeServingOrderRectoActionOpen,
        directoriesMultitudeServingOrderRectoActionShut: DirectoriesMultitudeServingOrderRectoActionShut,
        environmentVariablesFilesDirectory: EnvironmentVariablesFilesDirectory,
        logger: ILogger<EnvironmentVariablesSourceFilesDirectory>
    ) =
    member _.Populate() =
        let destinationDirectory = environmentVariablesFilesDirectory.GetPath()
        let environmentVariablesSourceDictionary = environmentVariablesFilesDirectory.PairUp()
        let templateSourceDirectory = environmentVariablesTemplatesDirectory.GetPath()

        for templateFile in Directory.EnumerateFiles(templateSourceDirectory) do
            try
                let destFileName = Path.GetFileName(templateFile)
                let destFile = Path.Combine(destinationDirectory, destFileName)

                let contentToWrite =
                    match destFileName with
                    | "directories-multitude-serving-order-reverse-action-open.env" -> directoriesMultitudeServingOrderReverseActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "directories-multitude-commanding-order-reverse-action-open.env" -> directoriesMultitudeCommandingOrderReverseActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "directories-multitude-commanding-order-recto-action-open.env" -> directoriesMultitudeCommandingOrderRectoActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "directories-multitude-commanding-order-recto-action-shut.env" -> directoriesMultitudeCommandingOrderRectoActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "directories-multitude-serving-order-recto-action-open.env" -> directoriesMultitudeServingOrderRectoActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "directories-multitude-serving-order-recto-action-shut.env" -> directoriesMultitudeServingOrderRectoActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "directories-multitude-startup-action-add.env" -> directoriesMultitudeStartupActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "directories-multitude-startup-action-open.env" -> directoriesMultitudeStartupActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "notepadplusplus-multitude-all-order-recto-action-open.env" -> notePadPlusPlusOpenAll.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "notepadplusplus-multitude-all-order-reverse-action-open.env" -> notepadPlusPlusMultitudeAllOrderReverseActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "notepadplusplus-multitude-all-order-recto-action-shut.env" -> notePadPlusPlusAllClose.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-rider-multitude-primary-action-open.env" -> ideJetbrainsRiderMultitudePrimaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-rider-multitude-secondary-action-open.env" -> ideJetbrainsRiderMultitudeSecondaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-rider-multitude-tertiary-action-open.env" -> ideJetbrainsRiderMultitudeTertiaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-webstorm-multitude-primary-action-open.env" -> ideJetbrainsWebstormMultitudePrimaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-webstorm-multitude-secondary-action-open.env" -> ideJetbrainsWebstormMultitudeSecondaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-webstorm-multitude-tertiary-action-open.env" -> ideJetbrainsWebstormMultitudeTertiaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-webstorm-multitude-primary-action-shut.env" -> ideJetbrainsWebstormMultitudePrimaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-webstorm-multitude-secondary-action-shut.env" -> ideJetbrainsWebstormMultitudeSecondaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-webstorm-multitude-tertiary-action-shut.env" -> ideJetbrainsWebstormMultitudeTertiaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-rider-multitude-primary-action-shut.env" -> ideJetbrainsRiderMultitudePrimaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-rider-multitude-secondary-action-shut.env" -> ideJetbrainsRiderMultitudeSecondaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-jetbrains-rider-multitude-tertiary-action-shut.env" -> ideJetbrainsRiderMultitudeTertiaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-default-multitude-primary-action-open.env" -> ideMicrosoftVscodeDefaultMultitudePrimaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-default-multitude-secondary-action-open.env" -> ideMicrosoftVscodeDefaultMultitudeSecondaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-default-multitude-tertiary-action-open.env" -> ideMicrosoftVscodeDefaultMultitudeTertiaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-default-multitude-primary-action-shut.env" -> ideMicrosoftVscodeDefaultMultitudePrimaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-default-multitude-secondary-action-shut.env" -> ideMicrosoftVscodeDefaultMultitudeSecondaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-default-multitude-tertiary-action-shut.env" -> ideMicrosoftVscodeDefaultMultitudeTertiaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-insiders-multitude-primary-action-open.env" -> ideMicrosoftVscodeInsidersMultitudePrimaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-insiders-multitude-secondary-action-open.env" -> ideMicrosoftVscodeInsidersMultitudeSecondaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-insiders-multitude-tertiary-action-open.env" -> ideMicrosoftVscodeInsidersMultitudeTertiaryActionOpen.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-insiders-multitude-primary-action-shut.env" -> ideMicrosoftVscodeInsidersMultitudePrimaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-insiders-multitude-secondary-action-shut.env" -> ideMicrosoftVscodeInsidersMultitudeSecondaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | "ide-microsoft-vscode-insiders-multitude-tertiary-action-shut.env" -> ideMicrosoftVscodeInsidersMultitudeTertiaryActionShut.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)
                    | _ -> Something.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary)

                use fs = File.Create(destFile)
                use writer = new StreamWriter(fs)
                for entry in contentToWrite do
                    writer.WriteLine($"{entry.Key}={entry.Value}")
            with _ ->
                logger.LogError("EnvironmentVariablesSourceFilesDirectory: template file {TemplateFile} could not be processed.", templateFile)
