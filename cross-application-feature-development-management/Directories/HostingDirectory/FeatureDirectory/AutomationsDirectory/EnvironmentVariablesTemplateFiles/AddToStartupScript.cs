using System.Text;
using cross_application_feature_development_management.Helpers;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles
{
    public class AddToStartupScript(
        CommandLineArgs commandLineArgs,
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

                switch (key)
                {
                    case "ALL_INCLUSIVE_DIRECTORY_ADDRESS":
                        {
                            var featureDirectoryPath = automationsDirectory.GetPath();
                            var addToStartupPath = Path.Combine(featureDirectoryPath, "aggregate-all-multitude-commanding-order-recto-action-open.bat");
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