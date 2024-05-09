using System.Text;

namespace EnvironmentVariablesManagement
{
    internal class Something 
    {
        public static Dictionary<string, string> PairUpVariablesWithTheirValue(string fileNamePath, Dictionary<string, string> environmentVariablesSourceDictionary) {

            Dictionary<string, string>  fileContentDictionaryToWriteToFile = [];

            const Int32 BufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = streamReader.ReadLine()) != null) 
            {
                string[] brokenLine = line.Split("=");
                string key = brokenLine[0];
                string value = brokenLine[1];
                string val;
                environmentVariablesSourceDictionary.TryGetValue(key, out val);
                fileContentDictionaryToWriteToFile.Add(key, val);
                Console.WriteLine("{0}={1}", key, val);
            }

            return fileContentDictionaryToWriteToFile;
        }

        public static Dictionary<string, string> ReadKeyValueFromFile(string fileNamePath) 
        {

            Dictionary<string, string>  fileContentDictionary  =  [];

            const Int32 BufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = streamReader.ReadLine()) != null) 
            {
                string[] brokenLine = line.Split("=");
                string key = brokenLine[0];
                string value = brokenLine[1];
                fileContentDictionary.Add(key, value);
            }
            return fileContentDictionary;
        }

        public static Dictionary<string, string> GetAllEnvironmentVariablesAndValuesFromSourceFile(string environmentVariablesSourceDirectory)
        {
            Dictionary<string, string>  keyValuePairs  = [];

            foreach (string file in Directory.EnumerateFiles(environmentVariablesSourceDirectory))
            {
                keyValuePairs = Something.ReadKeyValueFromFile(file);
            }

            return keyValuePairs;
        }

        public static string DropTemplateExtensionFromFileName(string fileName)  
        {
            string[] words = fileName.Split('.');
            string destFileName = words[0] + '.' + words[1];
            return destFileName;
        }

        public static string ConstructDestinationFileNameIncludingPath(string destinationDirectory, string destinationFileName)
        {
            return  destinationDirectory + '/' + destinationFileName;
        }

        public  static void CopyFileToDestinationDirectory(string file, string destinationDirectory)
        {
            string fileNMame = Path.GetFileName(file);
            string destFileName = Something.DropTemplateExtensionFromFileName(fileNMame);
            string destFilePathIncludingName = Something.ConstructDestinationFileNameIncludingPath(destinationDirectory, destFileName);
            File.Copy(file, destFilePathIncludingName);
        }

        public  static void CopyContentOfSourceDireectoryToDestinationDirectory(string sourceDirectory, string destinationDirectory)
        {
            foreach (string file in Directory.EnumerateFiles(sourceDirectory))
            {
                Something.CopyFileToDestinationDirectory(file, destinationDirectory);
            }
        }
    }
}