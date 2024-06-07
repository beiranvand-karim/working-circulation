using System.Text;
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class Something 
    {
        internal class FeatureNameDirectory 
        {

            public static Dictionary<string, string> PairUpVariablesWithTheirValue(
                IConfiguration configuration,
                string fileNamePath,
                Dictionary<string, string> environmentVariablesSourceDictionary
            ) {
                Dictionary<string, string> fileContentDictionaryToWriteToFile = [];

                const Int32 BufferSize = 128;
                using var fileStream = File.OpenRead(fileNamePath);
                using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
                String? line;

                while ((line = streamReader.ReadLine()) != null) 
                {
                    string[] brokenLine = line.Split("=");
                    string key = brokenLine[0];
                    string value = brokenLine[1];
                    _ = environmentVariablesSourceDictionary.TryGetValue(key, out string? val);

                    if(key == "DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS")
                    {
                        fileContentDictionaryToWriteToFile.Add(key, val ?? "");
                    }
                    else
                    {
                        var directoryName = CommandLineArgs.DirectoriesNameToKeyMap.GetValue(configuration, key);
                        var featureNameDirectoryPath = EnvironmentVariablesManagement.FeatureNameDirectory.GetPath(configuration);
                        var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);
                        string valueToWrite = string.Format("\"{0}\"", directoryThatIsGoingToBeOpen);
                        fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                    }
                }

                return fileContentDictionaryToWriteToFile;
            }

        }
        
        public static Dictionary<string, string> PairUpVariablesWithTheirValue(
            string fileNamePath,
            Dictionary<string, string> environmentVariablesSourceDictionary
        ) {
            Dictionary<string, string> fileContentDictionaryToWriteToFile = [];

            const Int32 BufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            String? line;

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

            const Int32 BufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            String? line;

            while ((line = streamReader.ReadLine()) != null)
            {
                string[] brokenLine = line.Split("=");
                string key = brokenLine[0];
                string value = brokenLine[1];
                fileContentDictionary.Add(key, value);
            }
            return fileContentDictionary;
        }

        public static Dictionary<string, string> GetAllEnvironmentVariablesAndValuesFromSourceFile(
            string environmentVariablesSourceDirectory
        ){
            Dictionary<string, string> keyValuePairs = [];

            foreach (string file in Directory.EnumerateFiles(environmentVariablesSourceDirectory))
            {
                keyValuePairs = ReadKeyValueFromFile(file);
            }

            return keyValuePairs;
        }
    }
}