using System.Text;
using System.Text.Json;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.Files.Jsons;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Names
{
    public class Something(
            ILogger<Something> logger,
            SecondaryApplication secondaryApplication,
            PersistentVariablesFile persistentVariablesFile,
            SeparationFilementDirectory separationFilementDirectory
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

        private static Dictionary<string, string> ReadKeyValueFromFile(string fileNamePath)
        {
            Dictionary<string, string> fileContentDictionary = [];

            const int bufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize);

            while (streamReader.ReadLine() is { } line)
            {
                var brokenLine = line.Split("=");
                var key = brokenLine[0];
                var value = brokenLine[1];
                fileContentDictionary.Add(key, value);
            }
            return fileContentDictionary;
        }

        public static string ToUnderscoreCase(string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        private static Dictionary<string, string> ReadKeyValueFromJsonFile<T>(string fileNamePath)
        {
            Dictionary<string, string> fileContentDictionary = [];

            using StreamReader r = new(fileNamePath);
            var json = r.ReadToEnd();

            var environmentVariables = Newtonsoft.Json.JsonConvert
                .DeserializeObject<T>(json);

            var dddd = JsonSerializer.Serialize(environmentVariables);
            var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(dddd);
            foreach (var (key, value1) in from kv in dict
                                          let key = ToUnderscoreCase(kv.Key).ToUpper()
                                          let value1 = kv.Value
                                          select (key, value1))
            {
                fileContentDictionary.Add(key, value1);
            }

            return fileContentDictionary;
        }

        private static Dictionary<string, string> ReadKeyValueFromVariablesFilementJsonFile<T>(string fileNamePath)
        {
            Dictionary<string, string> fileContentDictionary = [];

            using StreamReader r = new(fileNamePath);
            var json = r.ReadToEnd();

            var environmentVariables = Newtonsoft.Json.JsonConvert
                .DeserializeObject<T>(json);

            var environmentVariablesSerialized = JsonSerializer.Serialize(environmentVariables);
            var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(environmentVariablesSerialized);
            foreach (var (key, value1) in from kv in dict
                                          let key = ToUnderscoreCase(kv.Key).ToUpper()
                                          let value1 = kv.Value
                                          select (key, value1))
            {
                fileContentDictionary.Add(key, value1);
            }

            return fileContentDictionary;
        }

        public Dictionary<string, string> PairUpEnvironmentVariablesSeparationFilement()
        {
            var separationFilementDirectoryPath = separationFilementDirectory.GetPath();
            var environmentVariablesSourceDictionaryMutantVariablesFile =
                GetAllEnvironmentVariablesAndValuesFromSourceJsonFile<MutantVariables>(
                    separationFilementDirectoryPath
                );

            var persistentVariablesFilePath = persistentVariablesFile.GetPath();
            var environmentVariablesSourceDictionaryPersistentVariablesFile = ReadKeyValueFromVariablesFilementJsonFile<PersistentVariables>(persistentVariablesFilePath);

            var environmentVariablesConcatenated = environmentVariablesSourceDictionaryMutantVariablesFile
                .Concat(environmentVariablesSourceDictionaryPersistentVariablesFile)
                .ToDictionary(x => x.Key, x => x.Value);

            return environmentVariablesConcatenated;
        }

        public Dictionary<string, string> GetAllEnvironmentVariablesAndValuesFromSourceFile(
            string environmentVariablesSourceDirectory
        )
        {
            Dictionary<string, string> keyValuePairs = [];

            foreach (var file in Directory.EnumerateFiles(environmentVariablesSourceDirectory))
            {
                var extension = Path.GetExtension(file);

                if (file.Contains(secondaryApplication.GetName()) && extension == ".env")
                {
                    keyValuePairs = ReadKeyValueFromFile(file);
                }
            }

            return keyValuePairs;
        }

        public Dictionary<string, string> GetAllEnvironmentVariablesAndValuesFromSourceJsonFile<T>(
            string environmentVariablesSourceDirectory
        )
        {
            Dictionary<string, string> keyValuePairs = [];

            foreach (var file in Directory.EnumerateFiles(environmentVariablesSourceDirectory))
            {

                if (file.Contains(secondaryApplication.GetName()) && Path.GetExtension(file) == ".json")
                {
                    keyValuePairs = ReadKeyValueFromJsonFile<T>(file);
                }
            }

            return keyValuePairs;
        }
    }
}
