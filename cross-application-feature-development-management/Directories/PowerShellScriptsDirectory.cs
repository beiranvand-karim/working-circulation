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
        const string directoryNameInSourceCode = "powershell-scripts";

        public void CopyContentToDirectory(string destinationDirectory)
        {
            var sourceDirectory = GetPath();
            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public string GetPath()
        {
            var scriptsDirectoryName = scriptsDirectory.GetName();
            var powerShellDirectoryPathInSourceCode = Path.Combine(scriptsDirectoryName, directoryNameInSourceCode);
            return powerShellDirectoryPathInSourceCode;
        }
    }
}
