using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.BackEnd;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Calls;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.NotesAndMessages;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.Tools;
using cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.WebLinks;
using cross_application_feature_development_management.Names;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory
{
    public class CommandsDirectory(
        AutomationsDirectory automationsDirectory,
        EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
        FeatureDirectory featureDirectory,
        Directories directories,
        FrontEndDirectory.FrontEndDirectory frontEndDirectory,
        FrontEndHostDirectory frontEndHostDirectory,
        FrontEndGuestDirectory frontEndGuestDirectory,
        SecondaryApplication secondaryApplication,
        PrimaryApplication primaryApplication,
        OperationsDirectory.OperationsDirectory operationsDirectory,
        NotesAndMessagesDirectory notesAndMessagesDirectory,
        ToolsDirectory toolsDirectory,
        CallsDirectory callsDirectory,
        WebLinksDirectory webLinksDirectory,
        BackEndDirectory backEndDirectory
    )
    {
        const string directoryNameInFeature = "commands";

        public void Create()
        {
            var path = GetPath();
            Directory.CreateDirectory(path);
        }
        public string GetPath()
        {
            var directory = automationsDirectory.GetPath();
            var operationsDirectory = Path.Combine(directory, directoryNameInFeature);
            return operationsDirectory;
        }

        public void ReplaceFileNamesWithPaths(Dictionary<string, string> environmentVariablesSourceDictionary)
        {
            var commandsDirectoryPath = GetPath();
            var giversPath = environmentVariablesFilesDirectory.GetPath();
            var runHostApplicationPath = Path.Combine(commandsDirectoryPath, "run-primary-application.ps1");
            var runGuestApplicationPath = Path.Combine(commandsDirectoryPath, "run-secondary-application.ps1");

            foreach (var filePath in Directory.EnumerateFiles(commandsDirectoryPath))
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var giverFileName = $"{fileName}.env";
                var giverPath = Path.Combine(giversPath, giverFileName);

                directories.ReplaceFileNameWithPath(filePath, giverPath);

                switch (fileName)
                {
                    case "aggregate-all-multitude-commanding-order-recto-action-open":
                    case "aggregate-all-multitude-commanding-order-reverse-action-open":
                        directories.ReplaceFileNameWithPath(filePath, "run-primary-application.ps1", runHostApplicationPath);
                        directories.ReplaceFileNameWithPath(filePath, "run-secondary-application.ps1", runGuestApplicationPath);
                        break;
                    case "directories-multitude-commanding-order-recto-action-shut":
                    case "directories-multitude-serving-order-recto-action-shut":
                        directories.ReplaceFileNameWithPath(filePath, "FEATURE_SELF_ADDRESS", featureDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "OPERATIONS_DIRECTORY_PATH", operationsDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "FEND_ADDRESS", frontEndDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "FEND_HOST_ADDRESS", frontEndHostDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "FEND_GUEST_ADDRESS", frontEndGuestDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "BEND_ADDRESS", backEndDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "CALLS_ADDRESS", callsDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "TOOLS_ADDRESS", toolsDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "NOTES_MESSAGES_ADDRESS", notesAndMessagesDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "WEB_LINKS_ADDRESS", webLinksDirectory.GetPath());
                        break;
                    case "all":
                        directories.ReplaceFileNameWithPath(filePath, "run-primary-application.ps1", runHostApplicationPath);
                        directories.ReplaceFileNameWithPath(filePath, "run-secondary-application.ps1", runGuestApplicationPath);
                        break;
                    case "dotnet-multitude-primary-action-run":
                        directories.ReplaceFileNameWithPath(filePath, "run-primary-application.ps1", runHostApplicationPath);
                        break;
                    case "dotnet-multitude-secondary-action-run":
                        directories.ReplaceFileNameWithPath(filePath, "run-secondary-application.ps1", runGuestApplicationPath);
                        break;
                    case "docker-network-secondary-multitude-primary-action-stop":
                        directories.ReplaceFileNameWithPath(filePath, "primary-application-name", primaryApplication.GetName());
                        break;
                    case "docker-network-secondary-multitude-secondary-action-stop":
                        directories.ReplaceFileNameWithPath(filePath, "secondary-application-name", secondaryApplication.GetName());
                        break;
                    case "docker-network-secondary-multitude-two-action-stop":
                        directories.ReplaceFileNameWithPath(filePath, "primary-application-name", primaryApplication.GetName());
                        directories.ReplaceFileNameWithPath(filePath, "secondary-application-name", secondaryApplication.GetName());
                        break;
                    case "docker-network-secondary-multitude-all-action-start":
                        if(environmentVariablesSourceDictionary.TryGetValue("AZURE_CLIENT_SECRET_FROM_ENVIRONMENT_VARIABLES", out var azureClientSecretFromEnvironmentVariables))
                        {
                            directories.ReplaceFileNameWithPath(filePath, "AZURE_CLIENT_SECRET_FROM_ENVIRONMENT_VARIABLES", azureClientSecretFromEnvironmentVariables);
                        }
                        break;
                }
            }
        }
    }
}