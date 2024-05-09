// Program.cs
using EnvironmentVariablesManagement;
using Microsoft.Extensions.Configuration;

string repositoryDirectoryNameKey = "--repository-directory";

string workingCirculationDirectoryName = Path.Combine(Something.GetCommandLineArgByKey(repositoryDirectoryNameKey), "WorkingCirculation");
string environmeentVariablesManagementDirectoryName = Path.Combine(workingCirculationDirectoryName, "EnvironmeentVariablesManagement");

var builder = new ConfigurationBuilder();
builder.SetBasePath(environmeentVariablesManagementDirectoryName)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 
IConfiguration config = builder.Build();

string templatesDirectoryNameKey = config["EnvironmentVariablesCommandLineArgumentsNameKeys:TemplatesDirectoryNameKey"];
string destinationDirectoryNameKey = config["EnvironmentVariablesCommandLineArgumentsNameKeys:DestinationDirectoryNameKey"];
string environmentVariablesSourceDirectoryNameKey = config["EnvironmentVariablesCommandLineArgumentsNameKeys:EnvironmentVariablesSourceDirectoryNameKey"];
string scriptsDirectoryNameKey = config["EnvironmentVariablesCommandLineArgumentsNameKeys:ScriptsDirectoryNameKey"];

string templatesDirectoryName =  Something.GetCommandLineArgByKey(templatesDirectoryNameKey);
string destinationDirectoryName =  Something.GetCommandLineArgByKey(destinationDirectoryNameKey);
string environmentVariablesSourceDirectoryName =  Something.GetCommandLineArgByKey(environmentVariablesSourceDirectoryNameKey);
string scriptsDirectoryName =  Something.GetCommandLineArgByKey(scriptsDirectoryNameKey);

//  todo add conds that t both direcs would exists

string environmentVariablesSourceDirectory = Path.Combine(scriptsDirectoryName, environmentVariablesSourceDirectoryName);
string templateSourceDirectory = Path.Combine(scriptsDirectoryName, templatesDirectoryName);
string destinationDirectory = Path.Combine(scriptsDirectoryName, destinationDirectoryName);

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
