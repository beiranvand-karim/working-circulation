using cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles;
using cafdemalihapa.Directories.Hosting.Feature.Automations.ProcessesMetaData;
using cafdemalihapa.Directories.Hosting.Feature.BackEnd;
using cafdemalihapa.Directories.Hosting.Feature.BackEnd.BackEndPrimary;
using cafdemalihapa.Directories.Hosting.Feature.BackEnd.BackEndSecondary;
using cafdemalihapa.Directories.Hosting.Feature.Calls;
using cafdemalihapa.Directories.Hosting.Feature.Data;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndGuest;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndPrimary;
using cafdemalihapa.Directories.Hosting.Feature.NotesAndMessages;
using cafdemalihapa.Directories.Hosting.Feature.Tools;
using cafdemalihapa.Directories.Hosting.Feature.WebLinks;
using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.Hosting.Feature.Automations.Commands
{
    public class CommandsDirectory(
        AutomationsDirectory automationsDirectory,
        EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
        FrontEnd.FrontEndDirectory frontEndDirectory,
        FrontEndPrimaryDirectory frontEndPrimaryDirectory,
        FrontEndGuestDirectory frontEndGuestDirectory,
        SecondaryApplication secondaryApplication,
        PrimaryApplication primaryApplication,
        Operations.OperationsDirectory operationsDirectory,
        NotesAndMessagesDirectory notesAndMessagesDirectory,
        ToolsDirectory toolsDirectory,
        CallsDirectory callsDirectory,
        WebLinksDirectory webLinksDirectory,
        BackEndPrimaryDirectory backEndPrimaryDirectory,
        BackEndSecondaryDirectory backEndSecondaryDirectory,
        DataDirectory dataDirectory,
        ProcessesMetaDataDirectory processesMetaDataDirectory
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

        public void ReplaceFileNamesWithPaths()
        {
            var environmentVariablesSourceDictionary = environmentVariablesFilesDirectory.PairUp();
            var commandsDirectoryPath = GetPath();
            var giversPath = environmentVariablesFilesDirectory.GetPath();
            var runPrimaryApplicationPath = Path.Combine(commandsDirectoryPath, "run-primary-application.ps1");
            var runGuestApplicationPath = Path.Combine(commandsDirectoryPath, "run-secondary-application.ps1");

            foreach (var filePath in Directory.EnumerateFiles(commandsDirectoryPath))
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var giverFileName = $"{fileName}.env";
                var giverPath = Path.Combine(giversPath, giverFileName);

                DirectoryServices.ReplaceFileNameWithPath(filePath, giverPath);

                switch (fileName)
                {
                    case "aggregate-all-multitude-commanding-order-recto-action-open":
                    case "aggregate-all-multitude-commanding-order-reverse-action-open":
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "run-primary-application.ps1", runPrimaryApplicationPath);
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "run-secondary-application.ps1", runGuestApplicationPath);
                        break;
                    case "directories-multitude-commanding-order-recto-action-shut":
                    case "directories-multitude-serving-order-recto-action-shut":
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "FEATURE_SELF_ADDRESS", FeatureDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "OPERATIONS_DIRECTORY_PATH", operationsDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "FEND_ADDRESS", frontEndDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "FEND_PRIMARY_ADDRESS", frontEndPrimaryDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "FEND_GUEST_ADDRESS", frontEndGuestDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "BEND_ADDRESS", BackEndDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "BEND_PRIMARY_ADDRESS", backEndPrimaryDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "BEND_GUEST_ADDRESS", backEndSecondaryDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "CALLS_ADDRESS", callsDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "TOOLS_ADDRESS", toolsDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "NOTES_MESSAGES_ADDRESS", notesAndMessagesDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "WEB_LINKS_ADDRESS", webLinksDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "DATA_ADDRESS", dataDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "ENVIRONMENT_VARIABLES_FILES_ADDRESS", environmentVariablesFilesDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "AUTOMATIONS_ADDRESS", automationsDirectory.GetPath());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "PROCESSES_META_DATA_ADDRESS", processesMetaDataDirectory.GetPath());
                        break;
                    case "all":
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "run-primary-application.ps1", runPrimaryApplicationPath);
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "run-secondary-application.ps1", runGuestApplicationPath);
                        break;
                    case "dotnet-multitude-primary-action-run":
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "run-primary-application.ps1", runPrimaryApplicationPath);
                        break;
                    case "dotnet-multitude-secondary-action-run":
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "run-secondary-application.ps1", runGuestApplicationPath);
                        break;
                    case "docker-network-secondary-multitude-primary-action-stop":
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "primary-application-name", primaryApplication.GetName());
                        break;
                    case "docker-network-secondary-multitude-secondary-action-stop":
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "secondary-application-name", secondaryApplication.GetName());
                        break;
                    case "docker-network-secondary-multitude-two-action-stop":
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "primary-application-name", primaryApplication.GetName());
                        DirectoryServices.ReplaceFileNameWithPath(filePath, "secondary-application-name", secondaryApplication.GetName());
                        break;
                    case "docker-network-secondary-multitude-all-action-start":
                        if(environmentVariablesSourceDictionary.TryGetValue("AZURE_CLIENT_SECRET_FROM_ENVIRONMENT_VARIABLES", out var azureClientSecretFromEnvironmentVariables))
                        {
                            DirectoryServices.ReplaceFileNameWithPath(filePath, "AZURE_CLIENT_SECRET_FROM_ENVIRONMENT_VARIABLES", azureClientSecretFromEnvironmentVariables);
                        }
                        break;
                }
            }
        }
    }
}