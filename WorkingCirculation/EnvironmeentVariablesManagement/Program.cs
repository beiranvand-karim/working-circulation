using System.IO;

string sourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";

string destinationDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-files";

foreach (string file in Directory.EnumerateFiles(sourceDirectory))
{
    string contents = File.ReadAllText(file);
    Console.WriteLine(file);
}

