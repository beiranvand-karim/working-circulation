using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.OperationsDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Names;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories
{
    public class PowerShellScriptsDirectory(
        EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
        TargetDirectory targetDirectory,
        ScriptsDirectory scriptsDirectory,
        FeatureNameDirectory featureNameDirectory,
        Directories directories,
        AutomationsDirectory automationsDirectory,
        ILogger<PowerShellScriptsDirectory> logger,
        FrontEndDirectory frontEndDirectory,
        FrontEndHostDirectory frontEndHostDirectory,
        FrontEndGuestDirectory frontEndGuestDirectory,
        GuestApplicationName guestApplicationName,
        HostApplicationName hostApplicationName,
        OperationsDirectory operationsDirectory
        )
    {
        public void ReplaceFileNamesWithPaths(Dictionary<string, string> environmentVariablesSourceDictionary)
        {
            const string direcName = "powershell-scripts";
            var pathInTarget = ConstructPathToSelfInFeatureNameDirectory(direcName);
            var giversPath = environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory();
            var runHostApplicationPath = Path.Combine(pathInTarget, "run-host-application.ps1");
            var runGuestApplicationPath = Path.Combine(pathInTarget, "run-guest-application.ps1");


            foreach (var filePath in Directory.EnumerateFiles(pathInTarget))
            {

                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var giverFileName = $"{fileName}.env";
                var giverPath = Path.Combine(giversPath, giverFileName);

                directories.ReplaceFileNameWithPath(filePath, giverPath);

                switch (fileName)
                {
                    case "all-inclusive":
                    case "aggregate-all-multitude-commanding-order-reverse-action-open":
                        directories.ReplaceFileNameWithPath(filePath, "run-host-application.ps1", runHostApplicationPath);
                        directories.ReplaceFileNameWithPath(filePath, "run-guest-application.ps1", runGuestApplicationPath);
                        break;
                    case "directories-multitude-commanding-order-recto-action-shut":
                    case "directories-multitude-serving-order-recto-action-shut":
                        directories.ReplaceFileNameWithPath(filePath, "FEATURE_SELF_ADDRESS", featureNameDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "OPERATIONS_DIRECTORY_PATH", operationsDirectory.GetPath());
                        directories.ReplaceFileNameWithPath(filePath, "FEND_ADDRESS", frontEndDirectory.GetPath("FEND_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "FEND_HOST_ADDRESS", frontEndHostDirectory.GetPath("FEND_HOST_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "FEND_GUEST_ADDRESS", frontEndGuestDirectory.GetPath("FEND_GUEST_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "BEND_ADDRESS", frontEndDirectory.GetPath("BEND_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "CALLS_ADDRESS", frontEndDirectory.GetPath("CALLS_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "TOOLS_ADDRESS", frontEndDirectory.GetPath("TOOLS_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "NOTES_MESSAGES_ADDRESS", frontEndDirectory.GetPath("NOTES_MESSAGES_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "WEB_LINKS_ADDRESS", frontEndDirectory.GetPath("WEB_LINKS_ADDRESS"));
                        break;
                    case "all":
                        directories.ReplaceFileNameWithPath(filePath, "run-host-application.ps1", runHostApplicationPath);
                        directories.ReplaceFileNameWithPath(filePath, "run-guest-application.ps1", runGuestApplicationPath);
                        break;
                    case "dotnet-multitude-primary-order-recto-action-run":
                        directories.ReplaceFileNameWithPath(filePath, "run-host-application.ps1", runHostApplicationPath);
                        break;
                    case "dotnet-multitude-secondary-order-recto-action-run":
                        directories.ReplaceFileNameWithPath(filePath, "run-guest-application.ps1", runGuestApplicationPath);
                        break;
                    case "docker-network-secondary-multitude-primary-action-stop":
                        directories.ReplaceFileNameWithPath(filePath, "host-application-name", hostApplicationName.GetName());
                        break;
                    case "docker-network-secondary-multitude-secondary-action-stop":
                        directories.ReplaceFileNameWithPath(filePath, "guest-application-name", guestApplicationName.GetName());
                        break;
                    case "docker-network-secondary-multitude-two-action-stop":
                        directories.ReplaceFileNameWithPath(filePath, "host-application-name", hostApplicationName.GetName());
                        directories.ReplaceFileNameWithPath(filePath, "guest-application-name", guestApplicationName.GetName());
                        break;
                    case "docker-network-secondary-multitude-all-action-start":
                        environmentVariablesSourceDictionary.TryGetValue(
                            "AZURE_CLIENT_SECRET_FROM_ENVIRONMENT_VARIABLES",
                            out var azureClientSecretFromEnvironmentVariables
                        );
                        directories.ReplaceFileNameWithPath(filePath, "AZURE_CLIENT_SECRET_FROM_ENVIRONMENT_VARIABLES", azureClientSecretFromEnvironmentVariables ?? "");
                        break;
                }
            }
        }

        public void CopyContentToFeatureNameDirectory()
        {
            const string direcName = "powershell-scripts";
            Directory.CreateDirectory(ConstructPathToSelfInFeatureNameDirectory(direcName));
            var sourceDirectory = ConstructPathToSelfInScriptsDirectory(direcName);
            var destinationDirectory = ConstructPathToSelfInFeatureNameDirectory(direcName);

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        private string ConstructPathToSelfInScriptsDirectory(string direcName)
        {
            var scriptsDirectoryName = scriptsDirectory.GetName();
            var environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, direcName);
            return environmentVariablesFilesDirectory;
        }

        public string ConstructPathToSelfInFeatureNameDirectory(string direcName)
        {
            var destinationDirectory = automationsDirectory.GetPath();
            var environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, direcName);
            return environmentVariablesFilesDirectory;
        }
    }
}
