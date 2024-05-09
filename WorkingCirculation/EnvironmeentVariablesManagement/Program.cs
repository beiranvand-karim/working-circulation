// Program.cs
using EnvironmentVariablesManagement;

string templatesDirectoryNameKey = "--templates-directory";
string destinationDirectoryNameKey = "--destination-directory";
string environmentVariablesSourceDirectoryNameKey = "--environment-variables-source-directory";
string featureNameKey = "--feature-name";
string executiveFileDirectoryNameKey = "--executive-file-directory";
string scriptsDirectoryNameKey = "--scripts-directory";
string repositoryDirectoryNameKey = "--repository-directory";
string hostingDirectoryNameKey = "--hosting-directory";

Console.WriteLine(Something.GetCommandLineArgByKey(templatesDirectoryNameKey));
Console.WriteLine(Something.GetCommandLineArgByKey(destinationDirectoryNameKey));
Console.WriteLine(Something.GetCommandLineArgByKey(environmentVariablesSourceDirectoryNameKey));
Console.WriteLine(Something.GetCommandLineArgByKey(featureNameKey));
Console.WriteLine(Something.GetCommandLineArgByKey(executiveFileDirectoryNameKey));
Console.WriteLine(Something.GetCommandLineArgByKey(scriptsDirectoryNameKey));
Console.WriteLine(Something.GetCommandLineArgByKey(repositoryDirectoryNameKey));
Console.WriteLine(Something.GetCommandLineArgByKey(hostingDirectoryNameKey));

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
    string templateSourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";
    string destinationDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-files";

    Dictionary<string, string> environmentVariablesSourceDictionary = Something.GetAllEnvironmentVariablesAndValuesFromSourceFile(environmentVariablesSourceDirectory);

    foreach (string templateFile in Directory.EnumerateFiles(templateSourceDirectory))  
    {
        Dictionary<string, string> contentToWrite = Something.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);

        string destFileName = Path.GetFileNameWithoutExtension(templateFile);
        string destFile = Path.Combine(destinationDirectory, destFileName);
        using var fs = File.Create(destFile);

        using StreamWriter writer = new(fs);
        foreach (KeyValuePair<string, string> entry in contentToWrite)
        {
            string valueToWrite = $"""{entry.Key}={entry.Value}""";
            writer.WriteLine(valueToWrite);
        }
    }
}

