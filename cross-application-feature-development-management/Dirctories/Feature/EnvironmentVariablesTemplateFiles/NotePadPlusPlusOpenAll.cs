using System.Text;
using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Helpers.Interfaces;
using cross_application_feature_development_management.Names.Classses;
using cross_application_feature_development_management.Names.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Dirctories.Feature.EnvironmentVariablesTemplateFiles
{
    public interface INotePadPlusPlusOpenAll
    {
        public Dictionary<string, string> PairUpVariablesWithTheirValue(
            string fileNamePath,
            Dictionary<string, string> environmentVariablesSourceDictionary
        );
    }

    public class NotePadPlusPlusOpenAll(
        IFeatureName featureName,
        IGuestApplicationName guestApplicationName,
        IHostApplicationName hostApplicationName,
        IHostingDirectory hostingDirectory,
        ILogger<NotePadPlusPlusOpenAll> logger,
        IStringHelpers stringHelpers
    ) : INotePadPlusPlusOpenAll
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

            const int BufferSize = 128;
            using var fileStream = File.OpenRead(fileNamePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            string? line;

            while ((line = streamReader.ReadLine()) != null)
            {
                string[] brokenLine = line.Split("=");
                string key = brokenLine[0];
                string value = brokenLine[1];

                if (key == "FEATURE_NAME")
                {
                    string val = featureName.GetName();
                    string wrappedVal = stringHelpers.WrappInQoutationMarks(val);
                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                }
                else if (key == "HOST_APPLICATION_NAME")
                {
                    string val = hostApplicationName.GetName();
                    string wrappedVal = stringHelpers.WrappInQoutationMarks(val);
                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                }
                else if (key == "GUEST_APPLICATION_NAME")
                {
                    string val = guestApplicationName.GetName();
                    string wrappedVal = stringHelpers.WrappInQoutationMarks(val);
                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                }
                else if (key == "HOSTING_DIRECTORY")
                {
                    string val = hostingDirectory.GetName();
                    string wrappedVal = stringHelpers.WrappInQoutationMarks(val);
                    fileContentDictionaryToWriteToFile.Add(key, wrappedVal ?? "");
                }
                else if (key == "NOTEPAD_PLUS_PLUS_FILE_MANAGEMENT_EXECUTIVE_FILE_CONTAINING_DIRECTORY")
                {
                    environmentVariablesSourceDictionary.TryGetValue(
                        "NOTEPAD_PLUS_PLUS_FILE_MANAGEMENT_EXECUTIVE_FILE_LOCATION",
                        out string? notepadPlusPlusFileManagementExecutiveFileLocation
                        );
                    var striped = stringHelpers.StripQoutationMarks(notepadPlusPlusFileManagementExecutiveFileLocation ?? "");
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