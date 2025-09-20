using System.Diagnostics;
using System.Runtime.InteropServices;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.BackEnd;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Calls;
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
        ToolsDirectory toolsDirectory,
        BackEndDirectory backEndDirectory,
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
            if (!IsDirectoryManagementApplication())
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
            toolsDirectory.Create();
            backEndDirectory.Create();
            callsDirectory.Create();
            frontEndDirectory.Create();
            frontEndHostDirectory.Create();
            frontEndGuestDirectory.Create();
            notesAndMessagesDirectory.Create();
            webLinksDirectory.Create();
        }

        public void Open()
        {
            if(!IsOpen())
            {
                return;
            }

            var environmentVariablesSourceDictionary = environmentVariablesFilesDirectory.PairUp();

            var frontEndHostDirectoryPath = frontEndHostDirectory.GetPath();
            var frontEndGuestDirectoryPath = frontEndGuestDirectory.GetPath();
            var callsDirectoryPath = callsDirectory.GetPath();
            var toolsDirectoryPath = toolsDirectory.GetPath();
            var notesAndMessagesDirectoryPath = notesAndMessagesDirectory.GetPath();
            var webLinksDirectoryPath = webLinksDirectory.GetPath();


            if (environmentVariablesSourceDictionary.TryGetValue("IS_OPENING_FEND_HOST_ADDRESS", out string? isOpeningFendHostAddress))
            {
                if (Boolean.TryParse(isOpeningFendHostAddress, out bool isOpeningFendHostAddress1))
                {
                    if (isOpeningFendHostAddress1)
                    {
                        OpenDirectories(frontEndHostDirectoryPath);
                        Thread.Sleep(700);
                    }
                }
            }

            if (environmentVariablesSourceDictionary.TryGetValue("IS_OPENING_FEND_GUEST_ADDRESS", out string? isOpeningFendGuestAddress))
            {
                if (Boolean.TryParse(isOpeningFendGuestAddress, out bool isOpeningFendGuestAddress1))
                {
                    if (isOpeningFendGuestAddress1)
                    {
                        OpenDirectories(frontEndGuestDirectoryPath);
                        Thread.Sleep(700);
                    }
                }
            }

            if (environmentVariablesSourceDictionary.TryGetValue("IS_OPENING_CALLS_ADDRESS", out string? isOpeningCallsAddress))
            {
                if (Boolean.TryParse(isOpeningCallsAddress, out bool isOpeningCallsAddress1))
                {
                    if (isOpeningCallsAddress1)
                    {
                        OpenDirectories(callsDirectoryPath);
                        Thread.Sleep(700);
                    }
                }
            }

            if (environmentVariablesSourceDictionary.TryGetValue("IS_OPENING_TOOLS_ADDRESS", out string? isOpeningToolsAddress))
            {
                if (Boolean.TryParse(isOpeningToolsAddress, out bool isOpeningToolsAddress1))
                {
                    if (isOpeningToolsAddress1)
                    {
                        OpenDirectories(toolsDirectoryPath);
                        Thread.Sleep(700);
                    }
                }
            }


            if (environmentVariablesSourceDictionary.TryGetValue("IS_OPENING_NOTES_MESSAGES_ADDRESS", out string? isOpeningNotesMessagesAddress))
            {
                if (Boolean.TryParse(isOpeningNotesMessagesAddress, out bool isOpeningNotesMessagesAddress1))
                {
                    if (isOpeningNotesMessagesAddress1)
                    {
                        OpenDirectories(notesAndMessagesDirectoryPath);
                        Thread.Sleep(700);
                    }
                }
            }

            if (environmentVariablesSourceDictionary.TryGetValue("IS_OPENING_WEB_LINKS_ADDRESS", out string? isOpeningWebLinksAddress))
            {
                if (Boolean.TryParse(isOpeningWebLinksAddress, out bool isOpeningWebLinksAddress1))
                {
                    if (isOpeningWebLinksAddress1)
                    {
                        OpenDirectories(webLinksDirectoryPath);
                        Thread.Sleep(700);
                    }
                }
            }
        }

        public void Shut()
        {
            if(!IsShut())
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
        }
    }
}