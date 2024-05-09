// Program.cs
using EnvironmentVariablesManagement;
using Microsoft.Extensions.Configuration;

string repositoryDirectoryNameKey = "--repository-directory";

string workingCirculationDirectoryName = Path.Combine(Something.GetCommandLineArgByKey(repositoryDirectoryNameKey), "WorkingCirculation");
string environmeentVariablesManagementDirectoryName = Path.Combine(workingCirculationDirectoryName, "EnvironmeentVariablesManagement");
string appsettings = Path.Combine(environmeentVariablesManagementDirectoryName, "appsettings.json");

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile(appsettings, optional: false, reloadOnChange: true);
 
IConfiguration config = builder.Build();

string templatesDirectoryNameKey = config["EnvironmentVariablesCommandLineArgumeentsNameKeys:TemplatesDirectoryNameKey"];
string destinationDirectoryNameKey = config["EnvironmentVariablesCommandLineArgumeentsNameKeys:DestinationDirectoryNameKey"];
string environmentVariablesSourceDirectoryNameKey = config["EnvironmentVariablesCommandLineArgumeentsNameKeys:EnvironmentVariablesSourceDirectoryNameKey"];
string featureNameKey = config["EnvironmentVariablesCommandLineArgumeentsNameKeys:FeatureNameKey"];
string executiveFileDirectoryNameKey = config["EnvironmentVariablesCommandLineArgumeentsNameKeys:ExecutiveFileDirectoryNameKey"];
string scriptsDirectoryNameKey = config["EnvironmentVariablesCommandLineArgumeentsNameKeys:ScriptsDirectoryNameKey"];
string hostingDirectoryNameKey = config["EnvironmentVariablesCommandLineArgumeentsNameKeys:HostingDirectoryNameKey"];

string templatesDirectoryName =  Something.GetCommandLineArgByKey(templatesDirectoryNameKey);
string destinationDirectoryName =  Something.GetCommandLineArgByKey(destinationDirectoryNameKey);
string environmentVariablesSourceDirectoryName =  Something.GetCommandLineArgByKey(environmentVariablesSourceDirectoryNameKey);
string featureName =  Something.GetCommandLineArgByKey(featureNameKey);
string executiveFileDirectoryName =  Something.GetCommandLineArgByKey(executiveFileDirectoryNameKey);
string scriptsDirectoryName =  Something.GetCommandLineArgByKey(scriptsDirectoryNameKey);
string hostingDirectoryName =  Something.GetCommandLineArgByKey(hostingDirectoryNameKey);


Console.WriteLine(templatesDirectoryName);
Console.WriteLine(destinationDirectoryName);
Console.WriteLine(environmentVariablesSourceDirectoryName);
Console.WriteLine(featureName);
Console.WriteLine(executiveFileDirectoryName);
Console.WriteLine(scriptsDirectoryName);
Console.WriteLine(hostingDirectoryName);


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

