using System.Text;
using cross_application_feature_development_management.Helpers;
using cross_application_feature_development_management.Names;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles
{
    public class NotepadPlusPlusMultitudeAllOrderReverseActionOpen(
        FeatureName featureName,
        SecondaryApplication secondaryApplication,
        PrimaryApplication primaryApplication,
        HostingDirectory hostingDirectory,
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

                switch (key)
                {
                    case "FEATURE_NAME":
                        {
                            var val = featureName.GetName();
                            var wrappedVal = stringHelpers.WrapInQuotationMarks(val);
                            fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                            break;
                        }
                    case "PRIMARY_APPLICATION_NAME":
                        {
                            var val = primaryApplication.GetName();
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
                    case "APPLICATION":
                        {
                            var wrappedVal = stringHelpers.WrapInQuotationMarks("notepad-plus-plus-file-management");
                            fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                            break;
                        }
                    case "COMMAND":
                        {
                            var wrappedVal = stringHelpers.WrapInQuotationMarks("open");
                            fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                            break;
                        }
                    case "ORDER":
                        {
                            var wrappedVal = stringHelpers.WrapInQuotationMarks("reverse");
                            fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                            break;
                        }
                    case "NOTEPADDPP_EXECUTE_FILE_LOCATION":
                        {
                            if (environmentVariablesSourceDictionary.TryGetValue(key, out var keyValue))
                            {
                                var wrappedVal = stringHelpers.WrapInQuotationMarks(keyValue);
                                fileContentDictionaryToWriteToFile.Add(key, wrappedVal);
                            }
                            break;
                        }
                    case "NOTEPAD_PLUS_PLUS_FILE_MANAGEMENT_EXECUTIVE_FILE_CONTAINING_DIRECTORY":
                        {
                            environmentVariablesSourceDictionary.TryGetValue(
                                "NOTEPAD_PLUS_PLUS_FILE_MANAGEMENT_EXECUTIVE_FILE_LOCATION",
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