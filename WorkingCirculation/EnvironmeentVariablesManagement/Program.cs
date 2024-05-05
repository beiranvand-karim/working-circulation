
// Program.cs
using System.IO;
using System.Text;

int choice=2;

string sourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";

string destinationDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-files";

if (choice == 1) {
    foreach (string file in Directory.EnumerateFiles(sourceDirectory))
    {
        string destPath =  destinationDirectory + '/' + Path.GetFileName(file);
        string[] words = destPath.Split('.');
        string destFilePathName = words[0]  + '.' +  words[1];
        File.Copy(file, destFilePathName);
    }
}


//  todo add conds that t both direcs would exists


string environmentVariablesSourceDirectory  = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-source";


Dictionary<string, string>  keyValuePairs  =  [];

if (choice == 2) 
{
    foreach (string file in Directory.EnumerateFiles(environmentVariablesSourceDirectory))
    {
        const Int32 BufferSize = 128;
        using var fileStream = File.OpenRead(file);
        using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
        String line;
        while ((line = streamReader.ReadLine()) != null)
        {
            string[] brokenLine = line.Split("=");
            string key = brokenLine[0];
            string value = brokenLine[1];
            keyValuePairs.Add(key, value);
        }
    }
}

foreach (KeyValuePair<string, string> kvp in keyValuePairs)
{
    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
}
