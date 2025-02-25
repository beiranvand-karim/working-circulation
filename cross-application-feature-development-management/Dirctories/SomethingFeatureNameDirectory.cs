using System.Text;
using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Helpers.Interfaces;
using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Dirctories
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

            const int BufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            string? line;

            while ((line = streamReader.ReadLine()) != null)
            {
                string[] brokenLine = line.Split("=");
                string key = brokenLine[0];
                string value = brokenLine[1];
                _ = environmentVariablesSourceDictionary.TryGetValue(key, out string? val);


                if (key == "DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS")
                {
                    fileContentDictionaryToWriteToFile.Add(key, val ?? "");
                }
                else if (key == "DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY")
                {
                    environmentVariablesSourceDictionary.TryGetValue(
                        "DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS",
                        out string? directoryManagementExecutiveFileAddress
                        );
                    var striped = stringHelpers.StripQoutationMarks(directoryManagementExecutiveFileAddress ?? "");
                    var dirName = Path.GetDirectoryName(striped);
                    fileContentDictionaryToWriteToFile.Add(key, dirName ?? "");
                }
                else if (key == "FEND_HOST_ADDRESS")
                {
                    var directoryName = directoriesNameToKeyMap.GetValue(key);
                    var featureNameDirectoryPath = featureNameDirectory.GetPath();
                    var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);

                    var hostApplicationName = commandLineArgs.GetByKey("--host-application-name");

                    var x = string.Format("{0}.{1}", directoryName, hostApplicationName);

                    var directoryThatIsGoingToBeOpen2 = Path.Combine(directoryThatIsGoingToBeOpen, x);

                    string valueToWrite = string.Format("\"{0}\"", directoryThatIsGoingToBeOpen2);
                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                }
                else if (key == "FEND_GUEST_ADDRESS")
                {
                    var directoryName = directoriesNameToKeyMap.GetValue(key);
                    var featureNameDirectoryPath = featureNameDirectory.GetPath();
                    var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);

                    var guestApplicationName = commandLineArgs.GetByKey("--guest-application-name");

                    var x = string.Format("{0}.{1}", directoryName, guestApplicationName);

                    var directoryThatIsGoingToBeOpen2 = Path.Combine(directoryThatIsGoingToBeOpen, x);

                    string valueToWrite = string.Format("\"{0}\"", directoryThatIsGoingToBeOpen2);
                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                }
                else if (key == "FEATURE_SELF_ADDRESS")
                {
                    var featureNameDirectoryPath = featureNameDirectory.GetPath();
                    string valueToWrite = string.Format("\"{0}\"", featureNameDirectoryPath);
                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                }
                else if (key == "STARTUP_DIRECTORY_LOCATION")
                {
                    environmentVariablesSourceDictionary.TryGetValue(key, out string? val1);
                    fileContentDictionaryToWriteToFile.Add(key, val1 ?? "");
                }
                else
                {
                    var directoryName = directoriesNameToKeyMap.GetValue(key);
                    var featureNameDirectoryPath = featureNameDirectory.GetPath();
                    var directoryThatIsGoingToBeOpen = Path.Combine(featureNameDirectoryPath, directoryName);
                    string valueToWrite = string.Format("\"{0}\"", directoryThatIsGoingToBeOpen);
                    fileContentDictionaryToWriteToFile.Add(key, valueToWrite ?? "");
                }
            }

            return fileContentDictionaryToWriteToFile;
        }

    }
}