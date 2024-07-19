using System.Text;
using cross_application_feature_development_management.Names.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Names.Classses
{
    public class Something(
        ILogger<Something> logger,
        IHostApplicationName hostApplicationName
        ) : ISomething
    {
        private readonly IHostApplicationName hostApplicationName = hostApplicationName;
        private readonly ILogger<Something> logger = logger;

        public static Dictionary<string, string> PairUpVariablesWithTheirValue(
            string fileNamePath,
            Dictionary<string, string> environmentVariablesSourceDictionary
        )
        {
            Dictionary<string, string> fileContentDictionaryToWriteToFile = [];

            const int BufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            string? line;

            while ((line = streamReader.ReadLine()) != null)
            {
                string[] brokenLine = line.Split("=");
                string key = brokenLine[0];
                string value = brokenLine[1];
                _ = environmentVariablesSourceDictionary.TryGetValue(key, out string? val);
                fileContentDictionaryToWriteToFile.Add(key, val ?? "");
            }

            return fileContentDictionaryToWriteToFile;
        }

        public static Dictionary<string, string> ReadKeyValueFromFile(string fileNamePath)
        {
            Dictionary<string, string> fileContentDictionary = [];

            const int BufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            string? line;

            while ((line = streamReader.ReadLine()) != null)
            {
                string[] brokenLine = line.Split("=");
                string key = brokenLine[0];
                string value = brokenLine[1];
                fileContentDictionary.Add(key, value);
            }
            return fileContentDictionary;
        }

        public Dictionary<string, string> GetAllEnvironmentVariablesAndValuesFromSourceFile(
            string environmentVariablesSourceDirectory
        )
        {
            Dictionary<string, string> keyValuePairs = [];

            foreach (string file in Directory.EnumerateFiles(environmentVariablesSourceDirectory))
            {

                if(file.Contains(hostApplicationName.GetName()))
                {
                    logger.LogInformation("{hostApplicationName}", hostApplicationName.GetName());
                    logger.LogInformation("{file}", file);
                    keyValuePairs = ReadKeyValueFromFile(file);
                }
            }

            return keyValuePairs;
        }
    }
}