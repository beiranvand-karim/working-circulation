namespace cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.DirectoriesMultitude

open System.IO
open System.Text
open System.Collections.Generic
open Microsoft.Extensions.Logging
open cafdemwimu.console.Applications.Cafdemalihapa
open cafdemwimu.console.Directories.NullHelpers
open cafdemwimu.console.Directories.Hosting
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts
open cafdemwimu.console.Directories.Repository
open cafdemwimu.console.Helpers
open cafdemwimu.console.Names

type DirectoriesMultitudeCommandingOrderReverseActionOpen
    (
        stringHelpers: StringHelpers,
        primaryApplication: PrimaryApplication,
        secondaryApplication: SecondaryApplication,
        tertiaryApplication: TertiaryApplication,
        featureName: FeatureName,
        repositoryDirectory: RepositoryDirectory,
        codeBase: CodeBase,
        scriptsDirectory: ScriptsDirectory,
        logger: ILogger<DirectoriesMultitudeCommandingOrderReverseActionOpen>
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
            | true, _ ->
                try
                    match key with
                    | "FEATURE_NAME" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(featureName.GetName()))
                    | "CODE_BASE" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(codeBase.GetCodeBaseValue()))
                    | "COMMAND" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks("open"))
                    | "APPLICATION" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks("directory-management"))
                    | "ORDER" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks("recto"))
                    | "FORMAT" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks("json"))
                    | "FILEMENT" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks("split"))
                    | "REPOSITORY_DIRECTORY" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(repositoryDirectory.GetPath()))
                    | "CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY" ->
                        match environmentVariablesSourceDictionary.TryGetValue("CAFDEM_EXECUTIVE_FILE_ADDRESS") with
                        | true, cafdemExecutiveFileAddress ->
                            let striped = stringHelpers.StripQuotationMarks(cafdemExecutiveFileAddress)
                            let dirName = Path.GetDirectoryName(striped: string)
                            fileContentDictionaryToWriteToFile.Add(key, orEmpty dirName)
                        | _ -> ()
                    | "PRIMARY_APPLICATION_NAME" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(primaryApplication.GetName()))
                    | "SECONDARY_APPLICATION_NAME" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(secondaryApplication.GetName()))
                    | "TERTIARY_APPLICATION_NAME" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(tertiaryApplication.GetName()))
                    | "HOSTING_DIRECTORY" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(HostingDirectory.GetPath()))
                    | "SCRIPTS_DIRECTORY" -> fileContentDictionaryToWriteToFile.Add(key, stringHelpers.WrapInQuotationMarks(scriptsDirectory.GetPath()))
                    | _ ->
                        let _, val2 = environmentVariablesSourceDictionary.TryGetValue key
                        fileContentDictionaryToWriteToFile.Add(key, orEmpty val2)
                with _ ->
                    logger.LogError("DirectoriesMultitudeCommandingOrderReverseActionOpen: the key could not be processed: {Key}", key)
            | _ -> ()
            line <- streamReader.ReadLine()

        fileContentDictionaryToWriteToFile
