using System.Text;
using cross_application_feature_development_management.Helpers;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories
{
    public class SomethingFeatureNameDirectory(
        CommandLineArgs commandLineArgs,
        DirectoriesNameToKeyMap directoriesNameToKeyMap,
        FeatureNameDirectory featureNameDirectory,
        HostingDirectory hostingDirectory,
        ILogger<SomethingFeatureNameDirectory> logger,
        StringHelpers stringHelpers
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
                _ = environmentVariablesSourceDictionary.TryGetValue(key, out var val);


                switch (key)
                {
                    case "DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS":
                        fileContentDictionaryToWriteToFile.Add(key, val ?? "");
                        break;
                    case "DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY":
                    {
                        environmentVariablesSourceDictionary.TryGetValue(
                            "DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS",
                            out var directoryManagementExecutiveFileAddress
                        );
                        var striped = stringHelpers.StripQuotationMarks(directoryManagementExecutiveFileAddress ?? "");
                        var dirName = Path.GetDirectoryName(striped);
                        fileContentDictionaryToWriteToFile.Add(key, dirName ?? "");
                        break;
                    }
                    case "FEND_HOST_ADDRESS":
                    {
                        var directoryName = directoriesNameToKeyMap.GetValue(key);
                        var featureNameDirectoryPath = featureNameDirectory.GetPath();
                        var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);

                        var hostApplicationName = CommandLineArgs.GetByKey("--host-application-name");

                        var x = $"{directoryName}.{hostApplicationName}";

                        var directoryThatIsGoingToBeOpen2 = Path.Combine(directoryThatIsGoingToBeOpen, x);

                        var valueToWrite = $"\"{directoryThatIsGoingToBeOpen2}\"";
                        fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                        break;
                    }
                    case "FEND_GUEST_ADDRESS":
                    {
                        var directoryName = directoriesNameToKeyMap.GetValue(key);
                        var featureNameDirectoryPath = featureNameDirectory.GetPath();
                        var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);

                        var guestApplicationName = CommandLineArgs.GetByKey("--guest-application-name");

                        var x = $"{directoryName}.{guestApplicationName}";

                        var directoryThatIsGoingToBeOpen2 = Path.Combine(directoryThatIsGoingToBeOpen, x);

                        var valueToWrite = $"\"{directoryThatIsGoingToBeOpen2}\"";
                        fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                        break;
                    }
                    case "FEATURE_SELF_ADDRESS":
                    {
                        var featureNameDirectoryPath = featureNameDirectory.GetPath();
                        var valueToWrite = $"\"{featureNameDirectoryPath}\"";
                        fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                        break;
                    }
                    case "STARTUP_DIRECTORY_LOCATION":
                    case "IS_OPENING_FEND_HOST_ADDRESS":
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
                        var directoryName = directoriesNameToKeyMap.GetValue(key);
                        var featureNameDirectoryPath = featureNameDirectory.GetPath();
                        var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);
                        var valueToWrite = $"\"{directoryThatIsGoingToBeOpen}\"";
                        fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                        break;
                    }
                }
            }
            return fileContentDictionaryToWriteToFile;
        }
    }
}