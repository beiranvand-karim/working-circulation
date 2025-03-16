using System.Text;
using cross_application_feature_development_management.Directories;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Helpers;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Combiners
{
    public class AddToStartupScript(
        CommandLineArgs commandLineArgs,
        DirectoriesNameToKeyMap directoriesNameToKeyMap,
        FeatureNameDirectory featureNameDirectory,
        HostingDirectory hostingDirectory,
        ILogger<AddToStartupScript> logger,
        StringHelpers stringHelpers,
        AutomationsDirectory automationsDirectory
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

                switch (key)
                {
                    case "ALL_INCLUSIVE_DIRECTORY_ADDRESS":
                    {
                        var featureDirectoryPath = automationsDirectory.GetPath();
                        var addToStartupPath = Path.Combine(featureDirectoryPath, "all-inclusive.bat");
                        fileContentDictionaryToWriteToFile.Add(key, addToStartupPath);
                        break;
                    }
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
                    default:
                        environmentVariablesSourceDictionary.TryGetValue(key, out var val);
                        fileContentDictionaryToWriteToFile.Add(key, val ?? "");
                        break;
                }
            }

            return fileContentDictionaryToWriteToFile;
        }
    }
}