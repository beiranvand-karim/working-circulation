using System.Text;
using cafdemalihapa.Applications.Cafdemalihapa;
using cafdemalihapa.Directories.Repository;
using cafdemalihapa.Helpers;
using cafdemalihapa.Names;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.DirectoriesMultitude
{
    public class DirectoriesMultitudeCommandingOrderRectoActionOpen
    (
        StringHelpers stringHelpers,
        PrimaryApplication primaryApplication,
        SecondaryApplication secondaryApplication,
        FeatureName featureName,
        HostingDirectory hostingDirectory,
        RepositoryDirectory repositoryDirectory,
        CodeBase codeBase,
        ILogger<DirectoriesMultitudeCommandingOrderRectoActionOpen> logger
    )
    {
        public Dictionary<string, string> PairUpVariablesWithTheirValue(
            string fileNamePath,
            Dictionary<string, string> environmentVariablesSourceDictionary
        )
        {
            Dictionary<string, string> fileContentDictionaryToWriteToFile = [];

            const int bufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize);

            while (streamReader.ReadLine() is { } line)
            {
                var brokenLine = line.Split("=");
                var key = brokenLine[0];
                var value = brokenLine[1];

                if (environmentVariablesSourceDictionary.TryGetValue(key, out var val))
                {

                    try
                    {
                        switch (key)
                        {
                            case "COMMAND":
                                {
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks("open");
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            case "APPLICATION":
                                {
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks("directory-management");
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            case "ORDER":
                                {
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks("recto");
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            case "FORMAT":
                                {
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks("json");
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            case "FILEMENT":
                                {
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks("split");
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            case "REPOSITORY_DIRECTORY":
                                {
                                    var val3 = repositoryDirectory.GetPath();
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks(val3);
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            case "FEATURE_NAME":
                                {
                                    var val2 = featureName.GetName();
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks(val2);
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            case "CODE_BASE":
                                {
                                    var val2 = codeBase.GetCodeBaseValue();
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks(val2);
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            case "CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY":
                                {
                                    if (environmentVariablesSourceDictionary.TryGetValue(
                                        "CAFDEM_EXECUTIVE_FILE_ADDRESS",
                                        out var cafdemExecutiveFileAddress))
                                    {
                                        var striped = stringHelpers.StripQuotationMarks(cafdemExecutiveFileAddress);
                                        var dirName = Path.GetDirectoryName(striped);
                                        fileContentDictionaryToWriteToFile.Add(key, dirName ?? "");
                                    }
                                    break;
                                }
                            case "PRIMARY_APPLICATION_NAME":
                                {
                                    var val3 = primaryApplication.GetName();
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks(val3);
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            case "SECONDARY_APPLICATION_NAME":
                                {
                                    var val3 = secondaryApplication.GetName();
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks(val3);
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            case "HOSTING_DIRECTORY":
                                {
                                    var val3 = hostingDirectory.GetPath();
                                    var wrappedVal = stringHelpers.WrapInQuotationMarks(val3);
                                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                    break;
                                }
                            default:
                                {
                                    environmentVariablesSourceDictionary.TryGetValue(key, out var val2);
                                    fileContentDictionaryToWriteToFile.Add(key, val2 ?? "");
                                    break;
                                }
                        }
                    }
                    catch (Exception)
                    {
                        logger.LogError("DirectoriesMultitudeCommandingOrderRectoActionOpen: the key could not be processed: {Key}", key);

                    }
                }
            }
            return fileContentDictionaryToWriteToFile;
        }
    }
}