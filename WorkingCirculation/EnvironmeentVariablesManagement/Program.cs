
// Program.cs
using System.IO;

int choice=2;

string sourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";

string destinationDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-files";

string environmentVariablesSourceDirectory  = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-source";

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


if (choice == 2) 
{
    foreach (string file in Directory.EnumerateFiles(environmentVariablesSourceDirectory))
    {
        string contents = File.ReadAllText(file);
        Console.WriteLine(contents);
    }
}

