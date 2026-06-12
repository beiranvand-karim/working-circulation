namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.IdeMicrosoft

open System.IO
open System.Text
open System.Collections.Generic
open Microsoft.Extensions.Logging
open cafdemwimu.console.Directories.NullHelpers
open cafdemwimu.console.Directories.Hosting
open cafdemwimu.console.Helpers
open cafdemwimu.console.Names
open cafdemwimu.console.Applications.Cafdemalihapa

type IdeMicrosoftVscodeDefaultMultitudeTertiaryActionOpen
    (
        featureName: FeatureName,
        tertiaryApplication: TertiaryApplication,
        stringHelpers: StringHelpers,
        codeBase: CodeBase,
        logger: ILogger<IdeMicrosoftVscodeDefaultMultitudeTertiaryActionOpen>
    ) =
    member _.PairUpVariablesWithTheirValue
        (fileNamePath: string, environmentVariablesSourceDictionary: Dictionary<string, string>)
        =
        let fileContentDictionaryToWriteToFile: Dictionary<string,string> = Dictionary<string, string>()

        let bufferSize: int = 128
        use fileStream: FileStream = File.OpenRead(fileNamePath)
        use streamReader: StreamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize)

        let mutable line: string = streamReader.ReadLine()

        while not (isNull line) do
            let brokenLine: string array = line.Split('=')
            let key: string = brokenLine.[0]
            let _value: string = brokenLine.[1]

            try
                match key with
                | "FEATURE_NAME" ->
                    let wrappedFeatureName: string = featureName.GetWrappedName(stringHelpers)
                    fileContentDictionaryToWriteToFile.Add(key, wrappedFeatureName)
                | "TERTIARY_APPLICATION_NAME" ->
                    let wrappedTertiaryApplicationName: string =
                        tertiaryApplication.GetWrappedName(stringHelpers)

                    fileContentDictionaryToWriteToFile.Add(key, wrappedTertiaryApplicationName)
                | "HOSTING_DIRECTORY" ->
                    let wrappedHostingDirectory: string = HostingDirectory.GetWrappedPath(stringHelpers)
                    fileContentDictionaryToWriteToFile.Add(key, wrappedHostingDirectory)
                | "COMMAND" ->
                    let wrappedCommand: string = stringHelpers.WrapInQuotationMarks("open")
                    fileContentDictionaryToWriteToFile.Add(key, wrappedCommand)
                | "APPLICATION" ->
                    let wrappedApplication: string =
                        stringHelpers.WrapInQuotationMarks("ide-management")

                    fileContentDictionaryToWriteToFile.Add(key, wrappedApplication)
                | "IDE_NAME" ->
                    let wrappedIdeName: string = stringHelpers.WrapInQuotationMarks("vscode-default")
                    fileContentDictionaryToWriteToFile.Add(key, wrappedIdeName)
                | "VSCODE_LOCATION" ->
                    match environmentVariablesSourceDictionary.TryGetValue key with
                    | true, (keyValue: string) ->
                        let wrappedVscodeLocation: string = stringHelpers.WrapInQuotationMarks(keyValue)
                        fileContentDictionaryToWriteToFile.Add(key, wrappedVscodeLocation)
                    | _ -> ()
                | "CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY" ->
                    match environmentVariablesSourceDictionary.TryGetValue("CAFDEM_EXECUTIVE_FILE_ADDRESS") with
                    | true, (cafdemExecutiveFileAddress: string) ->
                        let dirName: string = codeBase.GetContainingDirectory(cafdemExecutiveFileAddress)
                        fileContentDictionaryToWriteToFile.Add(key, orEmpty dirName)
                    | _ -> ()
                | _ ->
                    let _, (v: string) = environmentVariablesSourceDictionary.TryGetValue key
                    let value: string = orEmpty v
                    fileContentDictionaryToWriteToFile.Add(key, value)
            with _ ->
                logger.LogError(
                    "IdeMicrosoftVscodeDefaultMultitudeTertiaryActionOpen: the key could not be processed: {Key}",
                    key
                )

            line <- streamReader.ReadLine()

        fileContentDictionaryToWriteToFile
