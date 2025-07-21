using System.Diagnostics;
using System.Runtime.InteropServices;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.BackEnd;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Calls;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.NotesAndMessages;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Tools;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.WebLinks;
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
        WebLinksDirectory webLinksDirectory
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

        public void Run()
        {
            if(!IsDirectoryManagementApplication())
            {
                return;
            }
            Create();
            Open();
            Shut();
        }

        public void Create()
        {
            if(!IsCreate())
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
            var frontEndDirectoryPath = frontEndDirectory.GetPath();
            var frontEndHostDirectoryPath = frontEndHostDirectory.GetPath();
            var frontEndGuestDirectoryPath = frontEndGuestDirectory.GetPath();
            var backEndDirectoryPath = backEndDirectory.GetPath();
            var callsDirectoryPath = callsDirectory.GetPath();
            var toolsDirectoryPath = toolsDirectory.GetPath();
            var notesAndMessagesDirectoryPath = notesAndMessagesDirectory.GetPath();
            var webLinksDirectoryPath = webLinksDirectory.GetPath();

            OpenDirectories(frontEndDirectoryPath);
            Thread.Sleep(700);

            OpenDirectories(frontEndHostDirectoryPath);
            Thread.Sleep(700);

            OpenDirectories(frontEndGuestDirectoryPath);
            Thread.Sleep(700);

            OpenDirectories(backEndDirectoryPath);
            Thread.Sleep(700);

            OpenDirectories(callsDirectoryPath);
            Thread.Sleep(700);

            OpenDirectories(toolsDirectoryPath);
            Thread.Sleep(700);

            OpenDirectories(notesAndMessagesDirectoryPath);
            Thread.Sleep(700);

            OpenDirectories(webLinksDirectoryPath);
            Thread.Sleep(700);
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