// Program.cs
using EnvironmentVariablesManagement;
using Microsoft.Extensions.Configuration;

try
{
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(WorkingCirculationDirectory.GetName())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    IConfiguration config = builder.Build();

    FeatureNameDirectory.CreateSelf(config);


    Directory.CreateDirectory(EnvironmentVariablesFilesDirectory.CreatePathToSelfInTargetDirectory());
    EnvironmentVariablesFilesDirectory.CopyContentToTargetDicrectory(config);

    PowerShellScriptsDirectory.CopyContentToTargetDicrectory(config);
    PowerShellScriptsDirectory.replaceFileNamesWithPaths();

    BatchScriptsDicrectory.CopyToTargetDicrectory(config);

    string templateSourceDirectory =
        Path.Combine(
            SriptsDirectory.GetName(config),
            TemplatesDirectory.GetName(config)
        );

    string destinationDirectory =
        Path.Combine(
            SriptsDirectory.GetName(config),
            EnvironmentVariablesFilesDirectory.GetName(config)
        );

    Dictionary<string, string> environmentVariablesSourceDictionary =
            Something.GetAllEnvironmentVariablesAndValuesFromSourceFile(
                EnvironmentVariablesSourceDirectory.GetName(config)
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
