namespace cafdemwimu.console.Applications

open System
open System.IO
open System.Text
open System.Linq
open System.Collections.Generic
open cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.SeparationFilement
open cafdemwimu.console.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.Files.Jsons

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
        let dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(variablesSerialized)
        for kv in dict do
            let key = (Something.ToUnderscoreCase kv.Key).ToUpper()
            let value = kv.Value
            fileContentDictionary.Add(key, value)

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
