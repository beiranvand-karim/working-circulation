using System.Text;
using cross_application_feature_development_management.Helpers;
using cross_application_feature_development_management.Names;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesTemplateFiles
{
    public class DirectoriesMultitudeServingOrderRectoActionOpen
    (
        StringHelpers stringHelpers,
        PrimaryApplication primaryApplication,
        SecondaryApplication secondaryApplication,
        FeatureName featureName
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
                
                if(environmentVariablesSourceDictionary.TryGetValue(key, out var val)){
                    switch (key)
                    {
                        case "COMMAND":
                        {
                            var wrappedVal = stringHelpers.WrapInQuotationMarks("open");
                            fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                            break;
                        }
                        case "APPLICATION":
                        {
                            var wrappedVal = stringHelpers.WrapInQuotationMarks("directory-management");
                            fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                            break;
                        }
                        case "ORDER":
                        {
                            var wrappedVal = stringHelpers.WrapInQuotationMarks("reverse");
                            fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                            break;
                        }
                        case "STARTUP_DIRECTORY_LOCATION":
                        {
                            environmentVariablesSourceDictionary.TryGetValue(key, out var val1);
                            fileContentDictionaryToWriteToFile.Add(key, val1 ?? "");
                            break;
                        }
                    case "CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY":
                        {
                            if(environmentVariablesSourceDictionary.TryGetValue(
                                "CAFDEM_EXECUTIVE_FILE_ADDRESS",
                                out var cafdemExecutiveFileAddress))
                                {
                                    var striped = stringHelpers.StripQuotationMarks(cafdemExecutiveFileAddress);
                                    var dirName = Path.GetDirectoryName(striped);
                                    fileContentDictionaryToWriteToFile.Add(key, dirName ?? "");
                                }
                            break;
                        }
                    case "PRIMARY_APPLICATION_NAME":
                        {
                            var val3 = primaryApplication.GetName();
                            var wrappedVal = stringHelpers.WrapInQuotationMarks(val3);
                            fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                            break;
                        }
                    case "FEATURE_NAME":
                        {
                            var val2 = featureName.GetName();
                            var wrappedVal = stringHelpers.WrapInQuotationMarks(val2);
                            fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                            break;
                        }
                    case "SECONDARY_APPLICATION_NAME":
                        {
                            var val3 = secondaryApplication.GetName();
                            var wrappedVal = stringHelpers.WrapInQuotationMarks(val3);
                            fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                            break;
                        }
                        default:
                        {
                            environmentVariablesSourceDictionary.TryGetValue(key, out var val2);
                            fileContentDictionaryToWriteToFile.Add(key, val2 ?? "");
                            break;
                        }
                    }
                }
            }
            return fileContentDictionaryToWriteToFile;
        }
    }
}