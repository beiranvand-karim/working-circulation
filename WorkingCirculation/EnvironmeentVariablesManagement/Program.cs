﻿// Program.cs
using EnvironmentVariablesManagement;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Something.GetEnvironmeentVariablesManagementDirectoryName())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 
IConfiguration config = builder.Build();

//  todo add conds that t both direcs would exists

string templateSourceDirectory = Path.Combine(
        Something.GetSriptsDirectoryName(config),
        Something.GetTemplatesDirectoryName(config)
    );

string destinationDirectory = Path.Combine(
        Something.GetSriptsDirectoryName(config),
        Something.GetDestinationDirectoryName(config)
    );

Dictionary<string, string> environmentVariablesSourceDictionary =
        Something.GetAllEnvironmentVariablesAndValuesFromSourceFile(
            Something.GetEnvironmentVariablesSourceDirectoryName(config)
        );

foreach (string templateFile in Directory.EnumerateFiles(templateSourceDirectory))  
{
    Dictionary<string, string> contentToWrite =
        Something.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);

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
