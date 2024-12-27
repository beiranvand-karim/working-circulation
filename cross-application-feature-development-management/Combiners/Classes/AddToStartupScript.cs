using System.Text;
using cross_application_feature_development_management.Combiners.Interfaces;
using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Helpers.Interfaces;
using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Combiners.Classes
{
    public class AddToStartupScript(
        ICommandLineArgs commandLineArgs,
        IDirectoriesNameToKeyMap directoriesNameToKeyMap,
        IFeatureNameDirectory featureNameDirectory,
        IHostingDirectory hostingDirectory,
        ILogger<AddToStartupScript> logger,
        IStringHelpers stringHelpers
        ) : IAddToStartupScript
    {

        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IDirectoriesNameToKeyMap directoriesNameToKeyMap = directoriesNameToKeyMap;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly IHostingDirectory hostingDirectory = hostingDirectory;
        private readonly ILogger<AddToStartupScript> logger = logger;
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

                if (key == "ALL_INCLUSIVE_DIRECTOY_ADDRESS")
                {
                    string featureDirectoryPath = featureNameDirectory.GetPath();
                    string addToStartupPath = Path.Combine(featureDirectoryPath, "all-inclusive.bat");
                    fileContentDictionaryToWriteToFile.Add(key, addToStartupPath);
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
                else
                {
                    environmentVariablesSourceDictionary.TryGetValue(key, out string? val);
                    fileContentDictionaryToWriteToFile.Add(key, val ?? "");
                }
            }

            return fileContentDictionaryToWriteToFile;
        }
    }
}