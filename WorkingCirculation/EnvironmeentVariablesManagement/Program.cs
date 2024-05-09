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
    string templateSourceDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-example-files";
    string destinationDirectory = "/Users/karimbeiranvand/Documents/GitHub/working-circulation/scripts/environment-variables-files";

    Dictionary<string, string> environmentVariablesSourceDictionary = Something.GetAllEnvironmentVariablesAndValuesFromSourceFile(environmentVariablesSourceDirectory);

    foreach (string templateFile in Directory.EnumerateFiles(templateSourceDirectory))  
    {
        Dictionary<string, string> contentToWrite = Something.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);

        string destFileName = Path.GetFileNameWithoutExtension(templateFile);
        string destFile = Path.Combine(destinationDirectory, destFileName);
        using (File.Create(destFile)){}

        using StreamWriter writer = new(destFile);
        foreach (KeyValuePair<string, string> entry in contentToWrite)
        {
            string valueToWrite = $"""{entry.Key}={entry.Value}""";
            writer.WriteLine(valueToWrite);
        }
    }
}

