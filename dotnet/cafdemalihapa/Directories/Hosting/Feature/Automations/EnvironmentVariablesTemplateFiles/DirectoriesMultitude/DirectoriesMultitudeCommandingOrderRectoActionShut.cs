using System.Text;
using cafdemalihapa.Directories.Hosting.Feature.BackEnd;
using cafdemalihapa.Directories.Hosting.Feature.Calls;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndGuest;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndPrimary;
using cafdemalihapa.Directories.Hosting.Feature.NotesAndMessages;
using cafdemalihapa.Directories.Hosting.Feature.Tools;
using cafdemalihapa.Directories.Hosting.Feature.WebLinks;
using cafdemalihapa.Helpers;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.DirectoriesMultitude
{
    public class DirectoriesMultitudeCommandingOrderRectoActionShut
    (
        StringHelpers stringHelpers,
        Operations.OperationsDirectory operationsDirectory,
        FrontEndPrimaryDirectory frontEndPrimaryDirectory,
        FrontEndGuestDirectory frontEndGuestDirectory,
        FrontEnd.FrontEndDirectory frontEndDirectory,
        CallsDirectory callsDirectory,
        ToolsDirectory toolsDirectory,
        NotesAndMessagesDirectory notesAndMessagesDirectory,
        WebLinksDirectory webLinksDirectory,
        ILogger<DirectoriesMultitudeCommandingOrderRectoActionShut> logger
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
                            case "DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS":
                                fileContentDictionaryToWriteToFile.Add(key, val ?? "");
                                break;
                            case "DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY":
                                {

                                    if (environmentVariablesSourceDictionary.TryGetValue("DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS", out var directoryManagementExecutiveFileAddress))
                                    {
                                        var striped = stringHelpers.StripQuotationMarks(directoryManagementExecutiveFileAddress);
                                        var dirName = Path.GetDirectoryName(striped);
                                        if (dirName is not null)
                                        {
                                            fileContentDictionaryToWriteToFile.Add(key, dirName);
                                        }
                                    }
                                    break;
                                }
                            case "FEND_PRIMARY_ADDRESS":
                                {
                                    var frontEndPrimaryDirectoryPath = frontEndPrimaryDirectory.GetPath();
                                    var valueToWrite = stringHelpers.WrapInQuotationMarks(frontEndPrimaryDirectoryPath);
                                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                                    break;
                                }
                            case "FEND_GUEST_ADDRESS":
                                {
                                    var frontEndGuestDirectoryPath = frontEndGuestDirectory.GetPath();
                                    var valueToWrite = stringHelpers.WrapInQuotationMarks(frontEndGuestDirectoryPath);
                                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                                    break;
                                }
                            case "FEATURE_SELF_ADDRESS":
                                {
                                    var featureDirectoryPath = FeatureDirectory.GetPath();
                                    var valueToWrite = stringHelpers.WrapInQuotationMarks(featureDirectoryPath);
                                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                                    break;
                                }
                            case "OPERATIONS_DIRECTORY_PATH":
                                {
                                    var operationsDirectoryPath = operationsDirectory.GetPath();
                                    var valueToWrite = stringHelpers.WrapInQuotationMarks(operationsDirectoryPath);
                                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                                    break;
                                }
                            case "FEND_ADDRESS":
                                {
                                    var frontEndDirectoryPath = frontEndDirectory.GetPath();
                                    var valueToWrite = stringHelpers.WrapInQuotationMarks(frontEndDirectoryPath);
                                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                                    break;
                                }
                            case "BEND_ADDRESS":
                                {
                                    var backEndDirectoryPath = BackEndDirectory.GetPath();
                                    var valueToWrite = stringHelpers.WrapInQuotationMarks(backEndDirectoryPath);
                                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                                    break;
                                }
                            case "CALLS_ADDRESS":
                                {
                                    var callsDirectoryPath = callsDirectory.GetPath();
                                    var valueToWrite = stringHelpers.WrapInQuotationMarks(callsDirectoryPath);
                                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                                    break;
                                }
                            case "TOOLS_ADDRESS":
                                {
                                    var toolsDirectoryPath = toolsDirectory.GetPath();
                                    var valueToWrite = stringHelpers.WrapInQuotationMarks(toolsDirectoryPath);
                                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                                    break;
                                }
                            case "NOTES_MESSAGES_ADDRESS":
                                {
                                    var notesAndMessagesDirectoryPath = notesAndMessagesDirectory.GetPath();
                                    var valueToWrite = stringHelpers.WrapInQuotationMarks(notesAndMessagesDirectoryPath);
                                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                                    break;
                                }
                            case "WEB_LINKS_ADDRESS":
                                {
                                    var webLinksDirectoryPath = webLinksDirectory.GetPath();
                                    var valueToWrite = stringHelpers.WrapInQuotationMarks(webLinksDirectoryPath);
                                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                                    break;
                                }
                            case "STARTUP_DIRECTORY_LOCATION":
                            case "IS_OPENING_OPERATIONS_DIRECTORY":
                            case "IS_OPENING_FEND_PRIMARY_ADDRESS":
                            case "IS_OPENING_FEND_GUEST_ADDRESS":
                            case "IS_OPENING_BEND_ADDRESS":
                            case "IS_OPENING_CALLS_ADDRESS":
                            case "IS_OPENING_TOOLS_ADDRESS":
                            case "IS_OPENING_NOTES_MESSAGES_ADDRESS":
                            case "IS_OPENING_WEB_LINKS_ADDRESS":
                            case "IS_OPENING_FEATURE_SELF_ADDRESS":
                            case "IS_OPENING_FEND_ADDRESS":
                                environmentVariablesSourceDictionary.TryGetValue(key, out var val1);
                                fileContentDictionaryToWriteToFile.Add(key, val1 ?? "");
                                break;
                            default:
                                {
                                    break;
                                }
                        }
                    }
                    catch (Exception)
                    {
                        logger.LogError("DirectoriesMultitudeCommandingOrderRectoActionShut: the key could not be processed: {Key}", key);
                    }
                }
            }
            return fileContentDictionaryToWriteToFile;
        }
    }
}