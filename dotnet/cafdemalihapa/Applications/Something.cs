using System.Text;
using System.Text.Json;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.SeparationFilement;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.Files.Jsons;

namespace cafdemalihapa.Applications
{
    public class Something(
            PersistentVariablesFile persistentVariablesFile,
            MutantVariablesFile mutantVariablesFile
        )
    {
        public static Dictionary<string, string> PairUpVariablesWithTheirValue(
            string fileNamePath,
            Dictionary<string, string> environmentVariablesSourceDictionary
        )
        {
            Dictionary<string, string> fileContentDictionaryToWriteToFile = [];

            const int bufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize);

            while (streamReader.ReadLine() is { } line)
            {
                var brokenLine = line.Split("=");
                var key = brokenLine[0];
                var value = brokenLine[1];
                _ = environmentVariablesSourceDictionary.TryGetValue(key, out var val);
                fileContentDictionaryToWriteToFile.Add(key, val ?? "");
            }

            return fileContentDictionaryToWriteToFile;
        }

        public static string ToUnderscoreCase(string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        private static Dictionary<string, string> ReadKeyValueFromJsonFile<T>(string path)
        {
            Dictionary<string, string> fileContentDictionary = [];

            using StreamReader r = new(path);
            var rawJsonData = r.ReadToEnd();

            var variables = Newtonsoft.Json.JsonConvert
                .DeserializeObject<T>(rawJsonData);

            var variablesSerialized = JsonSerializer.Serialize(variables);
            var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(variablesSerialized);
            foreach (var (key, value) in from kv in dict
                                         let key = ToUnderscoreCase(kv.Key).ToUpper()
                                         let value = kv.Value
                                         select (key, value))
            {
                fileContentDictionary.Add(key, value);
            }

            return fileContentDictionary;
        }

        public Dictionary<string, string> PairUpEnvironmentVariablesSeparationFilement()
        {
            var mutantVariablesFilePath = mutantVariablesFile.GetPath();
            var mutantVariablesDictionary =
                ReadKeyValueFromJsonFile<MutantVariables>(mutantVariablesFilePath);

            var persistentVariablesFilePath = persistentVariablesFile.GetPath();
            var persistentVariablesDictionary =
                ReadKeyValueFromJsonFile<PersistentVariables>(persistentVariablesFilePath);

            var environmentVariablesConcatenated = mutantVariablesDictionary
                .Concat(persistentVariablesDictionary)
                .ToDictionary(entry => entry.Key, entry => entry.Value);

            return environmentVariablesConcatenated;
        }
    }
}
