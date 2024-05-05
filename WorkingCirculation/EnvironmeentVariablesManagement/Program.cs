
// Program.cs
using System.IO;

string sourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";

string destinationDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-files";

foreach (string file in Directory.EnumerateFiles(sourceDirectory))
{
    string destPath =  destinationDirectory + '/' + Path.GetFileName(file);
    string[] words = destPath.Split('.');
    string destFilePathName = words[0]  + '.' +  words[1];
    File.Copy(file, destFilePathName);
}

//  todo add conds that t both direcs would exists
