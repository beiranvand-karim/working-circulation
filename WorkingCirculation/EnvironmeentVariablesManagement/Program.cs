// Program.cs
using EnvironmentVariablesManagement;

int choice = 2;

if (choice == 1)
{
    string sourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";

    string destinationDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-files";

    Something.CopyContentOfSourceDireectoryToDestinationDirectory(sourceDirectory, destinationDirectory);

}

//  todo add conds that t both direcs would exists

if (choice == 2) 
{
    string environmentVariablesSourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-source";

    Dictionary<string, string> environmentVariablesSourceDictionary = Something.GetAllEnvironmentVariablesAndValuesFromSourceFile(environmentVariablesSourceDirectory);

    string sourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";

    foreach (string file in Directory.EnumerateFiles(sourceDirectory))  
    {
        Console.WriteLine(file);
        Dictionary<string, string> contentToWrite = Something.PairUpVariablesWithTheirValue(file, environmentVariablesSourceDictionary);
    }
}

