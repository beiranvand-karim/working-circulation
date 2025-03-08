using System.Text;
using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Helpers.Interfaces;
using cross_application_feature_development_management.Names.Classses;
using cross_application_feature_development_management.Names.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.EnvironmentVariablesTemplateFiles
{
    public class IdeJetbrainsRiderMultitudeSecondaryActionShut(
        IFeatureName featureName,
        IGuestApplicationName guestApplicationName,
        IHostApplicationName hostApplicationName,
        IHostingDirectory hostingDirectory,
        ILogger<NotePadPlusPlusOpenAll> logger,
        IStringHelpers stringHelpers
    )
    {
        private readonly IFeatureName featureName = featureName;
        private readonly IGuestApplicationName guestApplicationName = guestApplicationName;
        private readonly IHostApplicationName hostApplicationName = hostApplicationName;
        private readonly IHostingDirectory hostingDirectory = hostingDirectory;
        private readonly ILogger<NotePadPlusPlusOpenAll> logger = logger;
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
                        var val = guestApplicationName.GetName();
                        var wrappedVal = stringHelpers.WrapInQuotationMarks(val);
                        fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                        break;
                    }
                    case "HOSTING_DIRECTORY":
                    {
                        var val = hostingDirectory.GetName();
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

            return fileContentDictionaryToWriteToFile;
        }
    }
}