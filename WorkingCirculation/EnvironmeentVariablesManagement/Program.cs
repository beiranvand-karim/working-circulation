
// Program.cs
using System.Text;

int choice=2;



if (choice == 1) {

    string sourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";

    string destinationDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-files";

    foreach (string file in Directory.EnumerateFiles(sourceDirectory))
    {
        string destPath =  destinationDirectory + '/' + Path.GetFileName(file);
        string[] words = destPath.Split('.');
        string destFilePathName = words[0]  + '.' +  words[1];
        File.Copy(file, destFilePathName);
    }
}


//  todo add conds that t both direcs would exists


static void DoThingsToFiles(string fileNamePath) {

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

        foreach (KeyValuePair<string, string> kvp in fileContentDictionary)
        {
            Console.WriteLine("fileContentDictionary: Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
}

static Dictionary<string,  string> readKeyValueFromFile(string fileNamePath) {

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

static Dictionary<string, string> getAllEnvironmentVariablesAndValuesFromSourceFile(string environmentVariablesSourceDirectory)
{

    Dictionary<string, string>  keyValuePairs  = [];

    foreach (string file in Directory.EnumerateFiles(environmentVariablesSourceDirectory))
    {
        keyValuePairs  =  readKeyValueFromFile(file);
    }

    return keyValuePairs;

}


if (choice == 2) 
{

    string environmentVariablesSourceDirectory  = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-source";

    Dictionary<string, string>  environmentVariablesSourceDictionary = getAllEnvironmentVariablesAndValuesFromSourceFile(environmentVariablesSourceDirectory);

    foreach (KeyValuePair<string, string> kvp in environmentVariablesSourceDictionary)
    {
        Console.WriteLine("environmentVariablesSourceDictionary: Key = {0}, Value = {1}", kvp.Key, kvp.Value);
    }


    string sourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";

    foreach (string file in Directory.EnumerateFiles(sourceDirectory))  
    {
        DoThingsToFiles(file);
    }

}


