namespace cafdemwimu.console.Applications

open System
open System.IO
open System.Text
open System.Text.Json
open System.Linq
open System.Collections.Generic
open Microsoft.Extensions.Logging
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource.Files.Jsons

type Something
    (
        persistentVariablesFile: PersistentVariablesFile,
        mutantVariablesFile: MutantVariablesFile,
        logger: ILogger<Something>
    ) =

    static member PairUpVariablesWithTheirValue
        (fileNamePath: string, environmentVariablesSourceDictionary: Dictionary<string, string>)
        =
        let fileContentDictionaryToWriteToFile = Dictionary<string, string>()

        let bufferSize = 128
        use fileStream = File.OpenRead(fileNamePath)
        use streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize)

        let mutable line = streamReader.ReadLine()

        while not (isNull line) do
            let brokenLine = line.Split('=')
            let key = brokenLine.[0]
            let _value = brokenLine.[1]
            let _, value = environmentVariablesSourceDictionary.TryGetValue key
            fileContentDictionaryToWriteToFile.Add(key, (if isNull value then "" else value))
            line <- streamReader.ReadLine()

        fileContentDictionaryToWriteToFile

    static member ToUnderscoreCase(str: string) =
        str
        |> Seq.mapi (fun i x -> if i > 0 && Char.IsUpper x then "_" + string x else string x)
        |> String.concat ""

        |> fun s -> s.ToLower()

    static member private ReadKeyValueFromJsonFile<'T>(path: string) =
        let fileContentDictionary = Dictionary<string, string>()

        use r = new StreamReader(path)
        let rawJsonData = r.ReadToEnd()

        let options = JsonSerializerOptions(PropertyNameCaseInsensitive = true)
        let variables = JsonSerializer.Deserialize<'T>(rawJsonData, options)

        let variablesSerialized = JsonSerializer.Serialize(variables)
        use document = JsonDocument.Parse(variablesSerialized)

        // Flatten the (possibly nested) object into UPPER_SNAKE keys, using leaf
        // property names so nested groups (e.g. "PrimaryApplication") still produce
        // the flat env keys (PRIMARY_APPLICATION_LOCATION, ...) that the templates expect.
        let rec flatten (element: JsonElement) =
            for property in element.EnumerateObject() do
                match property.Value.ValueKind with
                | JsonValueKind.Object -> flatten property.Value
                | _ ->
                    let key = (Something.ToUnderscoreCase property.Name).ToUpper()

                    let value =
                        match property.Value.ValueKind with
                        | JsonValueKind.Null -> ""
                        | JsonValueKind.True -> "true"
                        | JsonValueKind.False -> "false"
                        | JsonValueKind.String -> property.Value.GetString()
                        | _ -> property.Value.ToString()

                    fileContentDictionary.[key] <- value

        flatten document.RootElement

        fileContentDictionary

    member _.PairUpEnvironmentVariablesSeparationFilement() =
        let mutantVariablesFilePath: string = mutantVariablesFile.GetPath()
        let persistentVariablesFilePath: string = persistentVariablesFile.GetPath()

        let mutantVariablesDictionary: Dictionary<string, string> =
            Something.ReadKeyValueFromJsonFile<MutantVariables>(mutantVariablesFilePath)


        let persistentVariablesDictionary: Dictionary<string, string> =
            Something.ReadKeyValueFromJsonFile<PersistentVariables>(persistentVariablesFilePath)

        let environmentVariablesConcatenated: Dictionary<string, string> =
            mutantVariablesDictionary
                .Concat(persistentVariablesDictionary)
                .ToDictionary((fun (entry: KeyValuePair<string, string>) -> entry.Key), (fun entry -> entry.Value))

        environmentVariablesConcatenated
