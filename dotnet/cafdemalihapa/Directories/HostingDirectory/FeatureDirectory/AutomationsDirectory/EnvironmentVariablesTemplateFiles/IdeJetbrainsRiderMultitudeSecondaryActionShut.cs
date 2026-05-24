using System.Text;
using cafdemalihapa.Helpers;
using cafdemalihapa.Names;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles
{
    public class IdeJetbrainsRiderMultitudeSecondaryActionShut(
        FeatureName featureName,
        SecondaryApplication secondaryApplication,
        HostingDirectory hostingDirectory,
        StringHelpers stringHelpers,
        ILogger<IdeJetbrainsRiderMultitudeSecondaryActionShut> logger
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

                try
                {
                    switch (key)
                    {
                        case "FEATURE_NAME":
                            {
                                var val = featureName.GetName();
                                var wrappedVal = stringHelpers.WrapInQuotationMarks(val);
                                fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                break;
                            }
                        case "SECONDARY_APPLICATION_NAME":
                            {
                                var val = secondaryApplication.GetName();
                                var wrappedVal = stringHelpers.WrapInQuotationMarks(val);
                                fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                break;
                            }
                        case "HOSTING_DIRECTORY":
                            {
                                var val = hostingDirectory.GetPath();
                                var wrappedVal = stringHelpers.WrapInQuotationMarks(val);
                                fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                break;
                            }
                        case "COMMAND":
                            {
                                var wrappedVal = stringHelpers.WrapInQuotationMarks("close");
                                fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                break;
                            }
                        case "APPLICATION":
                            {
                                var wrappedVal = stringHelpers.WrapInQuotationMarks("ide-management");
                                fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                break;
                            }
                        case "IDE_NAME":
                            {
                                var wrappedVal = stringHelpers.WrapInQuotationMarks("rider");
                                fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                                break;
                            }
                        case "CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY":
                            {
                                environmentVariablesSourceDictionary.TryGetValue(
                                    "CAFDEM_EXECUTIVE_FILE_ADDRESS",
                                    out var notepadPlusPlusFileManagementExecutiveFileLocation
                                );
                                var striped = stringHelpers.StripQuotationMarks(notepadPlusPlusFileManagementExecutiveFileLocation ?? "");
                                var dirName = Path.GetDirectoryName(striped);
                                fileContentDictionaryToWriteToFile.Add(key, dirName ?? "");
                                break;
                            }
                        default:
                            {
                                environmentVariablesSourceDictionary.TryGetValue(key, out var val);
                                fileContentDictionaryToWriteToFile.Add(key, val ?? "");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    logger.LogError("IdeJetbrainsRiderMultitudeSecondaryActionShut: the key could not be processed: {Key}", key);
                }
            }
            return fileContentDictionaryToWriteToFile;
        }
    }
}