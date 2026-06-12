namespace cafdemwimu.console.Applications

open System
open System.IO
open System.Text
open System.Linq
open System.Collections.Generic
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource.SeparationFilement
open cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource.Files.Jsons

type Something(persistentVariablesFile: PersistentVariablesFile, mutantVariablesFile: MutantVariablesFile) =

    static member PairUpVariablesWithTheirValue(fileNamePath: string, environmentVariablesSourceDictionary: Dictionary<string, string>) =
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

        let variables = Newtonsoft.Json.JsonConvert.DeserializeObject<'T>(rawJsonData)

        let variablesSerialized = System.Text.Json.JsonSerializer.Serialize(variables)
        let root = Newtonsoft.Json.Linq.JObject.Parse(variablesSerialized)

        // Flatten the (possibly nested) object into UPPER_SNAKE keys, using leaf
        // property names so nested groups (e.g. "PrimaryApplication") still produce
        // the flat env keys (PRIMARY_APPLICATION_LOCATION, ...) that the templates expect.
        let rec flatten (jObject: Newtonsoft.Json.Linq.JObject) =
            for property in jObject.Properties() do
                match property.Value.Type with
                | Newtonsoft.Json.Linq.JTokenType.Object ->
                    flatten (property.Value :?> Newtonsoft.Json.Linq.JObject)
                | _ ->
                    let key = (Something.ToUnderscoreCase property.Name).ToUpper()
                    let value =
                        match property.Value.Type with
                        | Newtonsoft.Json.Linq.JTokenType.Null -> ""
                        | Newtonsoft.Json.Linq.JTokenType.Boolean -> property.Value.ToString().ToLower()
                        | _ -> property.Value.ToString()
                    fileContentDictionary.[key] <- value

        flatten root

        fileContentDictionary

    member _.PairUpEnvironmentVariablesSeparationFilement() =
        let mutantVariablesFilePath = mutantVariablesFile.GetPath()
        let mutantVariablesDictionary =
            Something.ReadKeyValueFromJsonFile<MutantVariables>(mutantVariablesFilePath)

        let persistentVariablesFilePath = persistentVariablesFile.GetPath()
        let persistentVariablesDictionary =
            Something.ReadKeyValueFromJsonFile<PersistentVariables>(persistentVariablesFilePath)

        let environmentVariablesConcatenated =
            mutantVariablesDictionary
                .Concat(persistentVariablesDictionary)
                .ToDictionary((fun entry -> entry.Key), (fun entry -> entry.Value))

        environmentVariablesConcatenated
