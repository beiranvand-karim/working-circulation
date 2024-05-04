using System.IO;

string sourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";

string destinationDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-files";

foreach (string file in Directory.EnumerateFiles(sourceDirectory))
{
    string destPath =  destinationDirectory + '/' + Path.GetFileName(file);
    File.Copy(file, destPath);
}

//  todo add conds that t both direcs would exists


string phrase = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-files/application user interface.env.example";
string[] words = phrase.Split('.');


string destFilePathName = words[0]  + '.' +  words[1];

Console.WriteLine(destFilePathName);