namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.DirectoriesMultitude

open System.IO
open System.Text
open System.Collections.Generic
open Microsoft.Extensions.Logging
open cafdemwimu.console.Directories.NullHelpers
open cafdemwimu.console.Directories.Hosting.Feature
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd
open cafdemwimu.console.Directories.Hosting.Feature.Calls
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndPrimary
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndSecondary
open cafdemwimu.console.Directories.Hosting.Feature.NotesAndMessages
open cafdemwimu.console.Directories.Hosting.Feature.Tools
open cafdemwimu.console.Directories.Hosting.Feature.WebLinks
open cafdemwimu.console.Directories.Hosting.Feature.Automations.Operations
open cafdemwimu.console.Helpers

type DirectoriesMultitudeCommandingOrderRectoActionShut
    (
        stringHelpers: StringHelpers,
        operationsDirectory: OperationsDirectory,
        frontEndPrimaryDirectory: FrontEndPrimaryDirectory,
        frontEndSecondaryDirectory: FrontEndSecondaryDirectory,
        frontEndDirectory: FrontEndDirectory,
        callsDirectory: CallsDirectory,
        toolsDirectory: ToolsDirectory,
        notesAndMessagesDirectory: NotesAndMessagesDirectory,
        webLinksDirectory: WebLinksDirectory,
        logger: ILogger<DirectoriesMultitudeCommandingOrderRectoActionShut>
    ) =
    member _.PairUpVariablesWithTheirValue(fileNamePath: string, environmentVariablesSourceDictionary: Dictionary<string, string>) =
        let fileContentDictionaryToWriteToFile = Dictionary<string, string>()

        let bufferSize = 128
        use fileStream = File.OpenRead(fileNamePath)
        use streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize)

        let mutable line = streamReader.ReadLine()
        while not (isNull line) do
            let brokenLine = line.Split('=')
            let key = brokenLine.[0]
            let _value = brokenLine.[1]
            match environmentVariablesSourceDictionary.TryGetValue key with
            | true, valFromSource ->
                try
                    match key with
                    | "CAFDEM_EXECUTIVE_FILE_ADDRESS" ->
                        fileContentDictionaryToWriteToFile.Add(key, orEmpty valFromSource)
                    | "CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY" ->
                        match environmentVariablesSourceDictionary.TryGetValue("CAFDEM_EXECUTIVE_FILE_ADDRESS") with
                        | true, cafdemExecutiveFileAddress ->
                            let striped = stringHelpers.StripQuotationMarks(cafdemExecutiveFileAddress)
                            let dirName = Path.GetDirectoryName(striped: string)
                            if not (isNull dirName) then
                                fileContentDictionaryToWriteToFile.Add(key, dirName)
                        | _ -> ()
                    | "FEND_PRIMARY_ADDRESS" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(frontEndPrimaryDirectory.GetPath()))
                    | "FEND_SECONDARY_ADDRESS" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(frontEndSecondaryDirectory.GetPath()))
                    | "FEATURE_SELF_ADDRESS" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(FeatureDirectory.GetPath()))
                    | "OPERATIONS_DIRECTORY_PATH" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(operationsDirectory.GetPath()))
                    | "FEND_ADDRESS" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(frontEndDirectory.GetPath()))
                    | "BEND_ADDRESS" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(BackEndDirectory.GetPath()))
                    | "CALLS_ADDRESS" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(callsDirectory.GetPath()))
                    | "TOOLS_ADDRESS" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(toolsDirectory.GetPath()))
                    | "NOTES_MESSAGES_ADDRESS" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(notesAndMessagesDirectory.GetPath()))
                    | "WEB_LINKS_ADDRESS" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(webLinksDirectory.GetPath()))
                    | "STARTUP_DIRECTORY_LOCATION"
                    | "IS_OPENING_OPERATIONS_DIRECTORY"
                    | "IS_OPENING_FEND_PRIMARY_ADDRESS"
                    | "IS_OPENING_FEND_SECONDARY_ADDRESS"
                    | "IS_OPENING_BEND_ADDRESS"
                    | "IS_OPENING_CALLS_ADDRESS"
                    | "IS_OPENING_TOOLS_ADDRESS"
                    | "IS_OPENING_NOTES_MESSAGES_ADDRESS"
                    | "IS_OPENING_WEB_LINKS_ADDRESS"
                    | "IS_OPENING_FEATURE_SELF_ADDRESS"
                    | "IS_OPENING_FEND_ADDRESS" ->
                        let _, val1 = environmentVariablesSourceDictionary.TryGetValue key
                        fileContentDictionaryToWriteToFile.Add(key, orEmpty val1)
                    | _ -> ()
                with _ ->
                    logger.LogError("DirectoriesMultitudeCommandingOrderRectoActionShut: the key could not be processed: {Key}", key)
            | _ -> ()
            line <- streamReader.ReadLine()

        fileContentDictionaryToWriteToFile
