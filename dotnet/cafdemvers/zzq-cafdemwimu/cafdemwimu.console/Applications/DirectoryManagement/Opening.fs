namespace cafdemwimu.console.Applications.DirectoryManagement

open System
open System.Threading
open System.Collections.Generic
open Microsoft.Extensions.Logging
open cafdemwimu.console.Applications
open cafdemwimu.console.Applications.DirectoryManagement.DirectoryOpenStrategies
open cafdemwimu.console.Names
open cafdemwimu.console.Directories.Hosting.Feature
open cafdemwimu.console.Directories.Hosting.Feature.Automations
open cafdemwimu.console.Directories.Hosting.Feature.Automations.Commands
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles
open cafdemwimu.console.Directories.Hosting.Feature.Automations.Operations
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

type Opening
    (
        logger: ILogger<Opening>,
        automationsDirectory: AutomationsDirectory,
        commandsDirectory: CommandsDirectory,
        operationsDirectory: OperationsDirectory,
        dataDirectory: DataDirectory,
        toolsDirectory: ToolsDirectory,
        backEndPrimaryDirectory: BackEndPrimaryDirectory,
        backEndSecondaryDirectory: BackEndSecondaryDirectory,
        callsDirectory: CallsDirectory,
        frontEndDirectory: FrontEndDirectory,
        frontEndPrimaryDirectory: FrontEndPrimaryDirectory,
        frontEndSecondaryDirectory: FrontEndSecondaryDirectory,
        notesAndMessagesDirectory: NotesAndMessagesDirectory,
        webLinksDirectory: WebLinksDirectory,
        environmentVariablesFilesDirectory: EnvironmentVariablesFilesDirectory,
        directoryToBeOpen: DirectoryToBeOpen,
        directoryOpenStrategies: IEnumerable<IDirectoryOpenStrategy>
    ) =
    member this.OpenDirectoryToBeOpen() =
        if Commands.Get().IsDirectoryToBeOpen() then
            let directoryToBeOpenPath = directoryToBeOpen.GetPath()
            this.OpenDirectories(directoryToBeOpenPath)

    member this.Open() =
        if Commands.Get().IsOpen() then
            let environmentVariablesSourceDictionary = environmentVariablesFilesDirectory.PairUp()

            let directoriesToOpen = Dictionary<string, string>()
            directoriesToOpen.Add("IS_OPENING_FEATURE_SELF_ADDRESS", FeatureDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_AUTOMATIONS_DIRECTORY", automationsDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_COMMANDS_DIRECTORY", commandsDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_ENVIRONMENT_VARIABLES_FILES_DIRECTORY", environmentVariablesFilesDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_OPERATIONS_DIRECTORY", operationsDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_BEND_ADDRESS", BackEndDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_BEND_PRIMARY_ADDRESS", backEndPrimaryDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_BEND_SECONDARY_ADDRESS", backEndSecondaryDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_DATA_DIRECTORY", dataDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_FEND_ADDRESS", frontEndDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_FEND_PRIMARY_ADDRESS", frontEndPrimaryDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_FEND_SECONDARY_ADDRESS", frontEndSecondaryDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_CALLS_ADDRESS", callsDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_TOOLS_ADDRESS", toolsDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_NOTES_MESSAGES_ADDRESS", notesAndMessagesDirectory.GetPath())
            directoriesToOpen.Add("IS_OPENING_WEB_LINKS_ADDRESS", webLinksDirectory.GetPath())

            for entry in directoriesToOpen do
                match environmentVariablesSourceDictionary.TryGetValue entry.Key with
                | true, value ->
                    match Boolean.TryParse(value) with
                    | true, shouldOpen when shouldOpen ->
                        this.OpenDirectories(entry.Value)
                        Thread.Sleep(700)
                    | _ -> ()
                | _ -> ()

    member _.OpenDirectories(path: string) =
        let strategy = directoryOpenStrategies |> Seq.tryFind (fun s -> s.CanHandle())

        match strategy with
        | None ->
            logger.LogWarning("Opening: no directory-open strategy supports the current operating system.")
        | Some strategy ->
            strategy.Open(path)
