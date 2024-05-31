// Program.cs
using EnvironmentVariablesManagement;
using Microsoft.Extensions.Configuration;

try
{
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(WorkingCirculationDirectory.GetName())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    IConfiguration config = builder.Build();

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

    FeatureNameDirectory.CreateSelf(config);

    Directory.CreateDirectory(EnvironmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory(config));
    EnvironmentVariablesFilesDirectory.CopyContentToFeatureNameDicrectory(config);

    PowerShellScriptsDirectory.CopyContentToFeatureNameDicrectory(config);
    PowerShellScriptsDirectory.replaceFileNamesWithPaths(config);

    BatchScriptsDicrectory.CopyContentToFeaureNameDicrectory(config);
    BatchScriptsDicrectory.replaceFileNamesWithPaths(config);

}
catch (System.Exception exception)
{
    Console.WriteLine(exception.Message);
}
