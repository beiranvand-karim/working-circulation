using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Directories.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Classes
{
    public class PowerShellScriptsDirectory(
        IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory,
        ITargetDirectory targetDirectory,
        IScriptsDirectory scriptsDirectory,
        IFeatureNameDirectory featureNameDirectory,
        IDirectories directories,
        IAutomationsDirectory automationsDirectory,
        ILogger<PowerShellScriptsDirectory> logger,
        IFrontEndDirectory frontEndDirectory,
        IFrontEndHostDirectory frontEndHostDirectory,
        IFrontEndGuestDirectory frontEndGuestDirectory
        ) : IPowerShellScriptsDirectory
    {
        private readonly IEnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory = environmentVariablesFilesDirectory;
        private readonly ITargetDirectory targetDirectory = targetDirectory;
        private readonly IScriptsDirectory scriptsDirectory = scriptsDirectory;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly IDirectories directories = directories;
        private readonly IAutomationsDirectory automationsDirectory = automationsDirectory;
        private readonly ILogger<PowerShellScriptsDirectory> logger = logger;
        private readonly IFrontEndDirectory frontEndDirectory = frontEndDirectory;
        private readonly IFrontEndHostDirectory frontEndHostDirectory = frontEndHostDirectory;
        private readonly IFrontEndGuestDirectory frontEndGuestDirectory = frontEndGuestDirectory;

        public void ReplaceFileNamesWithPaths()
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
                    case "all-inclusive.ps1":
                    case "all-inclusive-order-reverse.ps1":
                        directories.ReplaceFileNameWithPath(filePath, "run-host-application.ps1", runHostApplicationPath);
                        directories.ReplaceFileNameWithPath(filePath, "run-guest-application.ps1", runGuestApplicationPath);
                        break;
                    case "directories-multitude-all-action-close.ps1":
                        directories.ReplaceFileNameWithPath(filePath, "FEND_ADDRESS", frontEndDirectory.GetPath("FEND_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "FEND_HOST_ADDRESS", frontEndHostDirectory.GetPath("FEND_HOST_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "FEND_GUEST_ADDRESS", frontEndGuestDirectory.GetPath("FEND_GUEST_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "BEND_ADDRESS", frontEndDirectory.GetPath("BEND_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "CALLS_ADDRESS", frontEndDirectory.GetPath("CALLS_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "TOOLS_ADDRESS", frontEndDirectory.GetPath("TOOLS_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "NOTES_MESSAGES_ADDRESS", frontEndDirectory.GetPath("NOTES_MESSAGES_ADDRESS"));
                        directories.ReplaceFileNameWithPath(filePath, "WEB_LINKS_ADDRESS", frontEndDirectory.GetPath("WEB_LINKS_ADDRESS"));
                        break;
                    case "all.ps1":
                        directories.ReplaceFileNameWithPath(filePath, "run-host-application.ps1", runHostApplicationPath);
                        directories.ReplaceFileNameWithPath(filePath, "run-guest-application.ps1", runGuestApplicationPath);
                        break;
                    case "run-primary-application.ps1":
                        directories.ReplaceFileNameWithPath(filePath, "run-host-application.ps1", runHostApplicationPath);
                        break;
                    case "run-secondary-application.ps1":
                        directories.ReplaceFileNameWithPath(filePath, "run-guest-application.ps1", runGuestApplicationPath);
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

        public string ConstructPathToSelfInScriptsDirectory(string direcName)
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
