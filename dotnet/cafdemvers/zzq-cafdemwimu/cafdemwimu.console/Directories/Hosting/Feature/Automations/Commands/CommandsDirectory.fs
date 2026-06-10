namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.Commands

open System.IO
open cafdemwimu.console.Names
open cafdemwimu.console.Directories
open cafdemwimu.console.Directories.Hosting.Feature
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndPrimary
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndSecondary
open cafdemwimu.console.Directories.Hosting.Feature.Calls
open cafdemwimu.console.Directories.Hosting.Feature.Data
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndPrimary
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndSecondary
open cafdemwimu.console.Directories.Hosting.Feature.NotesAndMessages
open cafdemwimu.console.Directories.Hosting.Feature.Tools
open cafdemwimu.console.Directories.Hosting.Feature.WebLinks
open cafdemwimu.console.Directories.Hosting.Feature.Automations
open cafdemwimu.console.Directories.Hosting.Feature.Automations.Operations
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles
open cafdemwimu.console.Directories.Hosting.Feature.Automations.ProcessesMetaData

type CommandsDirectory
    (
        automationsDirectory: AutomationsDirectory,
        environmentVariablesFilesDirectory: EnvironmentVariablesFilesDirectory,
        frontEndDirectory: FrontEndDirectory,
        frontEndPrimaryDirectory: FrontEndPrimaryDirectory,
        frontEndSecondaryDirectory: FrontEndSecondaryDirectory,
        secondaryApplication: SecondaryApplication,
        primaryApplication: PrimaryApplication,
        operationsDirectory: OperationsDirectory,
        notesAndMessagesDirectory: NotesAndMessagesDirectory,
        toolsDirectory: ToolsDirectory,
        callsDirectory: CallsDirectory,
        webLinksDirectory: WebLinksDirectory,
        backEndPrimaryDirectory: BackEndPrimaryDirectory,
        backEndSecondaryDirectory: BackEndSecondaryDirectory,
        dataDirectory: DataDirectory,
        processesMetaDataDirectory: ProcessesMetaDataDirectory
    ) =
    let directoryNameInFeature = "commands"

    member this.Create() =
        let path = this.GetPath()
        Directory.CreateDirectory(path) |> ignore

    member _.GetPath() =
        let directory = automationsDirectory.GetPath()
        let commandsDirectory = Path.Combine(directory, directoryNameInFeature)
        commandsDirectory

    member this.ReplaceFileNamesWithPaths() =
        let environmentVariablesSourceDictionary = environmentVariablesFilesDirectory.PairUp()
        let commandsDirectoryPath = this.GetPath()
        let giversPath = environmentVariablesFilesDirectory.GetPath()
        let runPrimaryApplicationPath = Path.Combine(commandsDirectoryPath, "run-primary-application.ps1")
        let runSecondaryApplicationPath = Path.Combine(commandsDirectoryPath, "run-secondary-application.ps1")

        for filePath in Directory.EnumerateFiles(commandsDirectoryPath) do
            let fileName = Path.GetFileNameWithoutExtension(filePath)
            let giverFileName = $"{fileName}.env"
            let giverPath = Path.Combine(giversPath, giverFileName)

            DirectoryServices.ReplaceFileNameWithPath(filePath, giverPath)

            match fileName with
            | "aggregate-all-multitude-commanding-order-recto-action-open"
            | "aggregate-all-multitude-commanding-order-reverse-action-open" ->
                DirectoryServices.ReplaceFileNameWithPath(filePath, "run-primary-application.ps1", runPrimaryApplicationPath)
                DirectoryServices.ReplaceFileNameWithPath(filePath, "run-secondary-application.ps1", runSecondaryApplicationPath)
            | "directories-multitude-commanding-order-recto-action-shut"
            | "directories-multitude-serving-order-recto-action-shut" ->
                DirectoryServices.ReplaceFileNameWithPath(filePath, "FEATURE_SELF_ADDRESS", FeatureDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "OPERATIONS_DIRECTORY_PATH", operationsDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "FEND_ADDRESS", frontEndDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "FEND_PRIMARY_ADDRESS", frontEndPrimaryDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "FEND_SECONDARY_ADDRESS", frontEndSecondaryDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "BEND_ADDRESS", BackEndDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "BEND_PRIMARY_ADDRESS", backEndPrimaryDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "BEND_SECONDARY_ADDRESS", backEndSecondaryDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "CALLS_ADDRESS", callsDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "TOOLS_ADDRESS", toolsDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "NOTES_MESSAGES_ADDRESS", notesAndMessagesDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "WEB_LINKS_ADDRESS", webLinksDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "DATA_ADDRESS", dataDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "ENVIRONMENT_VARIABLES_FILES_ADDRESS", environmentVariablesFilesDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "AUTOMATIONS_ADDRESS", automationsDirectory.GetPath())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "PROCESSES_META_DATA_ADDRESS", processesMetaDataDirectory.GetPath())
            | "all" ->
                DirectoryServices.ReplaceFileNameWithPath(filePath, "run-primary-application.ps1", runPrimaryApplicationPath)
                DirectoryServices.ReplaceFileNameWithPath(filePath, "run-secondary-application.ps1", runSecondaryApplicationPath)
            | "dotnet-multitude-primary-action-run" ->
                DirectoryServices.ReplaceFileNameWithPath(filePath, "run-primary-application.ps1", runPrimaryApplicationPath)
            | "dotnet-multitude-secondary-action-run" ->
                DirectoryServices.ReplaceFileNameWithPath(filePath, "run-secondary-application.ps1", runSecondaryApplicationPath)
            | "docker-network-secondary-multitude-primary-action-stop" ->
                DirectoryServices.ReplaceFileNameWithPath(filePath, "primary-application-name", primaryApplication.GetName())
            | "docker-network-secondary-multitude-secondary-action-stop" ->
                DirectoryServices.ReplaceFileNameWithPath(filePath, "secondary-application-name", secondaryApplication.GetName())
            | "docker-network-secondary-multitude-two-action-stop" ->
                DirectoryServices.ReplaceFileNameWithPath(filePath, "primary-application-name", primaryApplication.GetName())
                DirectoryServices.ReplaceFileNameWithPath(filePath, "secondary-application-name", secondaryApplication.GetName())
            | "docker-network-secondary-multitude-all-action-start" ->
                match environmentVariablesSourceDictionary.TryGetValue("AZURE_CLIENT_SECRET_FROM_ENVIRONMENT_VARIABLES") with
                | true, azureClientSecretFromEnvironmentVariables ->
                    DirectoryServices.ReplaceFileNameWithPath(filePath, "AZURE_CLIENT_SECRET_FROM_ENVIRONMENT_VARIABLES", azureClientSecretFromEnvironmentVariables)
                | _ -> ()
            | _ -> ()
