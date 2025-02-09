using System.Text;
using cross_application_feature_development_management.Names.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Names.Classses
{
    public class Something(
        ILogger<Something> logger,
        IGuestApplicationName guestApplicationName
        ) : ISomething
    {
        private readonly IGuestApplicationName guestApplicationName = guestApplicationName;
        private readonly ILogger<Something> logger = logger;

        public Dictionary<string, string> PairUpVariablesWithTheirValue(
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
        private static Dictionary<string, string> ReadKeyValueFromJsonFile(string fileNamePath)
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

        public Dictionary<string, string> GetAllEnvironmentVariablesAndValuesFromSourceFile(
            string environmentVariablesSourceDirectory
        )
        {
            Dictionary<string, string> keyValuePairs = [];

            foreach (var file in Directory.EnumerateFiles(environmentVariablesSourceDirectory))
            {

                if(file.Contains(guestApplicationName.GetName()))
                {
                    logger.LogInformation("{guestApplicationName}", guestApplicationName.GetName());
                    logger.LogInformation("{file}", file);
                    keyValuePairs = ReadKeyValueFromFile(file);
                }
            }

            return keyValuePairs;
        }

        public Dictionary<string, string> GetAllEnvironmentVariablesAndValuesFromSourceJsonFile(
            string environmentVariablesSourceDirectory
        )
        {
            Dictionary<string, string> keyValuePairs = [];

            foreach (var file in Directory.EnumerateFiles(environmentVariablesSourceDirectory))
            {

                if(file.Contains(guestApplicationName.GetName()) && Path.GetExtension(file) == ".json" )
                {
                    logger.LogInformation("{guestApplicationName}", guestApplicationName.GetName());
                    logger.LogInformation("{file}", file);
                    keyValuePairs = ReadKeyValueFromJsonFile(file);

                }
            }

            return keyValuePairs;
        }
    }
}