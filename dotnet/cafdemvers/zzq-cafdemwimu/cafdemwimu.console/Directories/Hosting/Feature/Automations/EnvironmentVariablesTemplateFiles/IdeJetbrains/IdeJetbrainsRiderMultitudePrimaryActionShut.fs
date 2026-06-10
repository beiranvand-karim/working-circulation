namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.IdeJetbrains

open System.IO
open System.Text
open System.Collections.Generic
open Microsoft.Extensions.Logging
open cafdemwimu.console.Directories.NullHelpers
open cafdemwimu.console.Directories.Hosting
open cafdemwimu.console.Helpers
open cafdemwimu.console.Names

type IdeJetbrainsRiderMultitudePrimaryActionShut
    (
        featureName: FeatureName,
        primaryApplication: PrimaryApplication,
        stringHelpers: StringHelpers,
        logger: ILogger<IdeJetbrainsRiderMultitudePrimaryActionShut>
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
            try
                match key with
                | "FEATURE_NAME" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(featureName.GetName()))
                | "PRIMARY_APPLICATION_NAME" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(primaryApplication.GetName()))
                | "HOSTING_DIRECTORY" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(HostingDirectory.GetPath()))
                | "COMMAND" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks("close"))
                | "APPLICATION" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks("ide-management"))
                | "IDE_NAME" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks("rider"))
                | "CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY" ->
                    let _, notepadPlusPlusFileManagementExecutiveFileLocation = environmentVariablesSourceDictionary.TryGetValue("CAFDEM_EXECUTIVE_FILE_ADDRESS")
                    let striped = stringHelpers.StripQuotationMarks(orEmpty notepadPlusPlusFileManagementExecutiveFileLocation)
                    let dirName = Path.GetDirectoryName(striped: string)
                    fileContentDictionaryToWriteToFile.Add(key, orEmpty dirName)
                | _ ->
                    let _, v = environmentVariablesSourceDictionary.TryGetValue key
                    fileContentDictionaryToWriteToFile.Add(key, orEmpty v)
            with _ ->
                logger.LogError("IdeJetbrainsRiderMultitudePrimaryActionShut: the key could not be processed: {Key}", key)
            line <- streamReader.ReadLine()

        fileContentDictionaryToWriteToFile
