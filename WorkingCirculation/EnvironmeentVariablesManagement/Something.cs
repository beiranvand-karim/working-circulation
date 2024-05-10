using System.Text;
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class Something 
    {
        public static string GetSriptsDirectoryName(IConfiguration config)
        {
            string scriptsDirectoryNameKey =
                config["EnvironmentVariablesCommandLineArgumentsNameKeys:ScriptsDirectoryNameKey"];
            string scriptsDirectoryNameKey =
                config["EnvironmentVariablesCommandLineArgumentsNameKeys:ScriptsDirectoryNameKey"];
            string scriptsDirectoryName = GetCommandLineArgByKey(scriptsDirectoryNameKey);
            return scriptsDirectoryName;
        }

        public static string GetEnvironmentVariablesSourceDirectoryName(IConfiguration config)
        {
            string environmentVariablesSourceDirectoryNameKey =
                config["EnvironmentVariablesCommandLineArgumentsNameKeys:EnvironmentVariablesSourceDirectoryNameKey"];
            string environmentVariablesSourceDirectoryName = GetCommandLineArgByKey(environmentVariablesSourceDirectoryNameKey);
            string environmentVariablesSourceDirectory =
                Path.Combine(GetSriptsDirectoryName(config), environmentVariablesSourceDirectoryName);
            return environmentVariablesSourceDirectory;
        }

        public static string GetTemplatesDirectoryName(IConfiguration config)
        {
            string templatesDirectoryNameKey =
                config["EnvironmentVariablesCommandLineArgumentsNameKeys:TemplatesDirectoryNameKey"];

            string templatesDirectoryName = GetCommandLineArgByKey(templatesDirectoryNameKey);
            return templatesDirectoryName;
        }

        public static string GetDestinationDirectoryName(IConfiguration config)
        {
            string destinationDirectoryNameKey =
            config["EnvironmentVariablesCommandLineArgumentsNameKeys:DestinationDirectoryNameKey"];
            
            string destinationDirectoryName = GetCommandLineArgByKey(destinationDirectoryNameKey);
            return destinationDirectoryName;
        }

        public static string GetEnvironmeentVariablesManagementDirectoryName()
        {
            string repositoryDirectoryNameKey = "--repository-directory";
            string workingCirculationDirectoryName = Path.Combine(GetCommandLineArgByKey(repositoryDirectoryNameKey), "WorkingCirculation");
            string environmeentVariablesManagementDirectoryName = Path.Combine(workingCirculationDirectoryName, "EnvironmeentVariablesManagement");
            return environmeentVariablesManagementDirectoryName;
        }

        public static string GetCommandLineArgByKey(string CommandLineArgKey)
        {
            var commandLineArgs = Environment.GetCommandLineArgs();

            int index = Array.FindIndex(commandLineArgs, x => x.StartsWith(CommandLineArgKey));
            if(index > -1)
            {
                string CommandLineArgValue = commandLineArgs[index+1];
                return CommandLineArgValue;
            }

            return $"""could'nt find environment variable "{CommandLineArgKey}" ...""";
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