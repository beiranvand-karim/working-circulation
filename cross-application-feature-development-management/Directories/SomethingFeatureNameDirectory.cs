using System.Text;
using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Helpers.Interfaces;
using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories
{
    public class SomethingFeatureNameDirectory(
        ICommandLineArgs commandLineArgs,
        IDirectoriesNameToKeyMap directoriesNameToKeyMap,
        IFeatureNameDirectory featureNameDirectory,
        IHostingDirectory hostingDirectory,
        ILogger<SomethingFeatureNameDirectory> logger,
        IStringHelpers stringHelpers
        ) : ISomethingFeatureNameDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IDirectoriesNameToKeyMap directoriesNameToKeyMap = directoriesNameToKeyMap;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly IHostingDirectory hostingDirectory = hostingDirectory;
        private readonly ILogger<SomethingFeatureNameDirectory> logger = logger;
        private readonly IStringHelpers stringHelpers = stringHelpers;

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
                        var striped = stringHelpers.StripQoutationMarks(directoryManagementExecutiveFileAddress ?? "");
                        var dirName = Path.GetDirectoryName(striped);
                        fileContentDictionaryToWriteToFile.Add(key, dirName ?? "");
                        break;
                    }
                    case "FEND_HOST_ADDRESS":
                    {
                        var directoryName = directoriesNameToKeyMap.GetValue(key);
                        var featureNameDirectoryPath = featureNameDirectory.GetPath();
                        var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);

                        var hostApplicationName = commandLineArgs.GetByKey("--host-application-name");

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

                        var guestApplicationName = commandLineArgs.GetByKey("--guest-application-name");

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