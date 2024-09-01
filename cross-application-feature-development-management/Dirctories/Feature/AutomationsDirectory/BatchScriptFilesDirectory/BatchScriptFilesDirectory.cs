
public interface IBatchScriptFilesDirectory
{
    public string GetPath();
    public void Populate();
}

public class BatchScriptFilesDirectory : IBatchScriptFilesDirectory
{
    public string GetPath()
    {

    }

    public void Populate()
    {
        foreach (string templateFile in Directory.EnumerateFiles(templateSourceDirectory))
        {
            string destFileName = Path.GetFileNameWithoutExtension(templateFile);
            string destFile = Path.Combine(destinationDirectory, destFileName);
            using var fs = File.Create(destFile);

            Dictionary<string, string> contentToWrite = [];

            if (templateFile.Contains("directories"))
            {
                contentToWrite =
                somethingFeatureNameDirectory.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
            }
            else if (templateFile.Contains("startup"))
            {
                contentToWrite =
                addToStartupScript.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
            }
            else if (templateFile.Contains("notepadpp-open-all"))
            {
                contentToWrite =
                notePadPlusPlusOpenAll.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
            }
            else
            {
                contentToWrite =
                something.PairUpVariablesWithTheirValue(templateFile, environmentVariablesSourceDictionary);
            }

            using StreamWriter writer = new(fs);
            foreach (KeyValuePair<string, string> entry in contentToWrite)
            {
                string valueToWrite = $"""{entry.Key}={entry.Value}""";
                writer.WriteLine(valueToWrite);
            }

        }
    }
}