using cafdemalihapa.Applications.DirectoryManagement.DirectoryOpenStrategies;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.OperationsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.BackEnd;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.BackEnd.BackEndPrimaryDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.BackEnd.BackEndSecondaryDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.Calls;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.DataDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndGuestDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndHostDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.NotesAndMessages;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.Tools;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.WebLinks;
using cafdemalihapa.Names;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Applications.DirectoryManagement
{
    public class Opening
    (
        ILogger<Opening> logger,
        FeatureDirectory featureDirectory,
        AutomationsDirectory automationsDirectory,
        CommandsDirectory commandsDirectory,
        OperationsDirectory operationsDirectory,
        DataDirectory dataDirectory,
        ToolsDirectory toolsDirectory,
        BackEndDirectory backEndDirectory,
        BackEndPrimaryDirectory backEndPrimaryDirectory,
        BackEndSecondaryDirectory backEndSecondaryDirectory,
        CallsDirectory callsDirectory,
        FrontEndDirectory frontEndDirectory,
        FrontEndHostDirectory frontEndHostDirectory,
        FrontEndGuestDirectory frontEndGuestDirectory,
        NotesAndMessagesDirectory notesAndMessagesDirectory,
        WebLinksDirectory webLinksDirectory,
        EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
        DirectoryToBeOpen directoryToBeOpen,
        IEnumerable<IDirectoryOpenStrategy> directoryOpenStrategies
    )
    {
        public void OpenDirectoryToBeOpen()
        {
            if (!Commands.Get().IsDirectoryToBeOpen())
            {
                return;
            }
            var directoryToBeOpenPath = directoryToBeOpen.GetPath();
            OpenDirectories(directoryToBeOpenPath);
        }

        public void Open()
        {
            if (!Commands.Get().IsOpen())
            {
                return;
            }

            var environmentVariablesSourceDictionary = environmentVariablesFilesDirectory.PairUp();

            var directoriesToOpen = new Dictionary<string, string>
            {
                { "IS_OPENING_FEATURE_SELF_ADDRESS", featureDirectory.GetPath() },
                { "IS_OPENING_AUTOMATIONS_DIRECTORY", automationsDirectory.GetPath() },
                { "IS_OPENING_COMMANDS_DIRECTORY", commandsDirectory.GetPath() },
                { "IS_OPENING_ENVIRONMENT_VARIABLES_FILES_DIRECTORY", environmentVariablesFilesDirectory.GetPath() },
                { "IS_OPENING_OPERATIONS_DIRECTORY", operationsDirectory.GetPath() },
                { "IS_OPENING_BEND_ADDRESS", backEndDirectory.GetPath() },
                { "IS_OPENING_BEND_PRIMARY_ADDRESS", backEndPrimaryDirectory.GetPath() },
                { "IS_OPENING_BEND_SECONDARY_ADDRESS", backEndSecondaryDirectory.GetPath() },
                { "IS_OPENING_DATA_DIRECTORY", dataDirectory.GetPath() },
                { "IS_OPENING_FEND_ADDRESS", frontEndDirectory.GetPath() },
                { "IS_OPENING_FEND_HOST_ADDRESS", frontEndHostDirectory.GetPath() },
                { "IS_OPENING_FEND_GUEST_ADDRESS", frontEndGuestDirectory.GetPath() },
                { "IS_OPENING_FEND_PRIMARY_ADDRESS", frontEndHostDirectory.GetPath() },
                { "IS_OPENING_FEND_SECONDARY_ADDRESS", frontEndGuestDirectory.GetPath() },
                { "IS_OPENING_CALLS_ADDRESS", callsDirectory.GetPath() },
                { "IS_OPENING_TOOLS_ADDRESS", toolsDirectory.GetPath() },
                { "IS_OPENING_NOTES_MESSAGES_ADDRESS", notesAndMessagesDirectory.GetPath() },
                { "IS_OPENING_WEB_LINKS_ADDRESS", webLinksDirectory.GetPath() },
            };

            foreach (var (key, path) in directoriesToOpen)
            {
                if (environmentVariablesSourceDictionary.TryGetValue(key, out string? value))
                {
                    if (bool.TryParse(value, out bool shouldOpen) && shouldOpen)
                    {
                        OpenDirectories(path);
                        Thread.Sleep(700);
                    }
                }
            }
        }

        public void OpenDirectories(string path)
        {
            var strategy = directoryOpenStrategies.FirstOrDefault(s => s.CanHandle());

            if (strategy is null)
            {
                logger.LogWarning("Opening: no directory-open strategy supports the current operating system.");
                return;
            }

            strategy.Open(path);
        }
    }
}
