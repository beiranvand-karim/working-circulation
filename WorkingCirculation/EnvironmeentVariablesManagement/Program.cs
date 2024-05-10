// Program.cs
using EnvironmentVariablesManagement;
using Microsoft.Extensions.Configuration;

try
{
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(Dictionaries.GetEnvironmeentVariablesManagementDirectoryName())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    IConfiguration config = builder.Build();

    // todo add condis that both direcs would exists

    string templateSourceDirectory = 
        Path.Combine(
            Dictionaries.GetSriptsDirectoryName(config),
            Dictionaries.GetTemplatesDirectoryName(config)
        );

    string destinationDirectory = 
        Path.Combine(
            Dictionaries.GetSriptsDirectoryName(config),
            Dictionaries.GetDestinationDirectoryName(config)
        );

    Dictionary<string, string> environmentVariablesSourceDictionary =
            Something.GetAllEnvironmentVariablesAndValuesFromSourceFile(
                Dictionaries.GetEnvironmentVariablesSourceDirectoryName(config)
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
 
}
catch (System.ArgumentException)
{
    Console.WriteLine("necess --repository-directory");
}


