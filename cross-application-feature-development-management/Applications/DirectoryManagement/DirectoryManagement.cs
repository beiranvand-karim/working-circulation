using System.Diagnostics;
using System.Runtime.InteropServices;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.OperationsDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.BackEnd;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.BackEnd.BackEndPrimaryDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.BackEnd.BackEndSecondaryDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Calls;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.DataDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.NotesAndMessages;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Tools;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.WebLinks;
using cross_application_feature_development_management.Names;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Applications.DirectoryManagement
{
    public class DirectoryManagement
    (
        ILogger<DirectoryManagement> logger,
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
        DirectoryToBeOpen directoryToBeOpen
    )
    {
        private string GetCommand()
        {
            var command = CommandLineArgs.GetByKey("--command");
            return command;
        }

        private bool IsCreate()
        {
            var command = GetCommand();
            return command == "create";
        }

        private bool IsOpen()
        {
            var command = GetCommand();
            return command == "open";
        }

        private bool IsShut()
        {
            var command = GetCommand();
            return command == "shut";
        }

        private string GetApplication()
        {
            var application = CommandLineArgs.GetByKey("--application");
            return application;
        }

        private bool IsDirectoryManagementApplication()
        {
            var application = GetApplication();
            return application == "directory-management";
        }

        private bool IsDirectoryToBeOpen()
        {
            var command = GetCommand();
            return command == "directory-to-be-open";
        }

        public void Run()
        {
            if (!IsDirectoryManagementApplication())
            {
                return;
            }
            OpenDirectoryToBeOpen();
            Create();
            Open();
            Shut();
        }

        public void OpenDirectoryToBeOpen()
        {
            if (!IsDirectoryToBeOpen())
            {
                return;
            }
            var directoryToBeOpen1 = directoryToBeOpen.GetPath();
            OpenDirectories(directoryToBeOpen1);
        }

        public void Create()
        {
            if (!IsCreate())
            {
                return;
            }
            var directoriesToCreate = new List<Action>
            {
                toolsDirectory.Create,
                backEndDirectory.Create,
                backEndPrimaryDirectory.Create,
                backEndSecondaryDirectory.Create,
                callsDirectory.Create,
                dataDirectory.Create,
                frontEndDirectory.Create,
                frontEndHostDirectory.Create,
                frontEndGuestDirectory.Create,
                notesAndMessagesDirectory.Create,
                webLinksDirectory.Create,
            };

            foreach (var create in directoriesToCreate)
            {
                create();
            }
        }

        public void Open()
        {
            if (!IsOpen())
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

        public void Shut()
        {
            if (!IsShut())
            {
                return;
            }
        }

        public void OpenDirectories(string path)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                logger.LogInformation("path: {path}", path);

                using Process myProcess = new();
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "open";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.ArgumentList.Add(path);

                myProcess.Start();
                logger.LogInformation("myProcess: {myProcess}", myProcess.Id);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                using Process myProcess = new();
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "explorer.exe";
                myProcess.StartInfo.CreateNoWindow = true;
                var normalizedPath = PathUtility.NormalizeSlashes(path, PathUtility.SlashStyle.ForceBackslash);

                logger.LogInformation("path: {path}", path);
                logger.LogInformation("normalizedPath: {normalizedPath}", normalizedPath);

                myProcess.StartInfo.ArgumentList.Add(normalizedPath);

                myProcess.Start();
                logger.LogInformation("myProcess: {myProcess}", myProcess.Id);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                using Process myProcess = new();
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "xdg-open";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.ArgumentList.Add(path);

                myProcess.Start();
                logger.LogInformation("path: {path}", path);
                logger.LogInformation("myProcess: {myProcess}", myProcess.Id);
            }

        }
    }
}