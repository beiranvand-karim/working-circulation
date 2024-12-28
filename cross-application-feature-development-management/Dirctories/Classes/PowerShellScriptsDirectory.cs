using cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Dirctories.Feature.FrontEndDirectory;
using cross_application_feature_development_management.Dirctories.Feature.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Dirctories.Feature.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Dirctories.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Dirctories.Classes
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
            string direcName = "powershell-scripts";
            string pathInTarget = ConstructPathToSelfInFeatureNameDirectory(direcName);
            string giversPath = environmentVariablesFilesDirectory.CreatePathToSelfInFeatureNameDirectory();
            string runHostApplicationPath = Path.Combine(pathInTarget, "run-host-application.ps1");
            string runGuestApplicationPath = Path.Combine(pathInTarget, "run-guest-application.ps1");


            foreach (string filePath in Directory.EnumerateFiles(pathInTarget))
            {

                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string giverFileName = $"""{fileName}.env""";
                string giverPath = Path.Combine(giversPath, giverFileName);

                directories.ReplaceFileNameWithPath(filePath, giverPath);

                if (filePath.Contains("all-inclusive.ps1"))
                {
                    directories.ReplaceFileNameWithPath(filePath, "run-host-application.ps1", runHostApplicationPath);
                    directories.ReplaceFileNameWithPath(filePath, "run-guest-application.ps1", runGuestApplicationPath);
                }
                else if (filePath.Contains("all-inclusive-order-reverse.ps1"))
                {
                    directories.ReplaceFileNameWithPath(filePath, "run-host-application.ps1", runHostApplicationPath);
                    directories.ReplaceFileNameWithPath(filePath, "run-guest-application.ps1", runGuestApplicationPath);
                }
                else if (filePath.Contains("directories-multitude-all-action-close.ps1"))
                {
                    directories.ReplaceFileNameWithPath(filePath, "FEND_ADDRESS", frontEndDirectory.GetPath("FEND_ADDRESS"));
                    directories.ReplaceFileNameWithPath(filePath, "FEND_HOST_ADDRESS", frontEndHostDirectory.GetPath("FEND_HOST_ADDRESS"));
                    directories.ReplaceFileNameWithPath(filePath, "FEND_GUEST_ADDRESS", frontEndGuestDirectory.GetPath("FEND_GUEST_ADDRESS"));
                    directories.ReplaceFileNameWithPath(filePath, "BEND_ADDRESS", frontEndDirectory.GetPath("BEND_ADDRESS"));
                    directories.ReplaceFileNameWithPath(filePath, "CALLS_ADDRESS", frontEndDirectory.GetPath("CALLS_ADDRESS"));
                    directories.ReplaceFileNameWithPath(filePath, "TOOLS_ADDRESS", frontEndDirectory.GetPath("TOOLS_ADDRESS"));
                    directories.ReplaceFileNameWithPath(filePath, "NOTES_MESSAGES_ADDRESS", frontEndDirectory.GetPath("NOTES_MESSAGES_ADDRESS"));
                    directories.ReplaceFileNameWithPath(filePath, "WEB_LINKS_ADDRESS", frontEndDirectory.GetPath("WEB_LINKS_ADDRESS"));
                }
                else if (filePath.Contains("all.ps1"))
                {
                    directories.ReplaceFileNameWithPath(filePath, "run-host-application.ps1", runHostApplicationPath);
                    directories.ReplaceFileNameWithPath(filePath, "run-guest-application.ps1", runGuestApplicationPath);
                }
                else if (filePath.Contains("run-primary-application.ps1"))
                {
                    directories.ReplaceFileNameWithPath(filePath, "run-host-application.ps1", runHostApplicationPath);
                }
                else if (filePath.Contains("run-seconday-application.ps1"))
                {
                    directories.ReplaceFileNameWithPath(filePath, "run-guest-application.ps1", runGuestApplicationPath);
                }
            }
        }

        public void CopyContentToFeatureNameDicrectory()
        {
            string direcName = "powershell-scripts";
            Directory.CreateDirectory(ConstructPathToSelfInFeatureNameDirectory(direcName));
            string sourceDirectory = ConstructPathToSelfInScriptsDirectory(direcName);
            string destinationDirectory = ConstructPathToSelfInFeatureNameDirectory(direcName);

            directories.CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory, destinationDirectory);
        }

        public string ConstructPathToSelfInScriptsDirectory(string direcName)
        {
            string scriptsDirectoryName = scriptsDirectory.GetName();
            string environmentVariablesFilesDirectory = Path.Combine(scriptsDirectoryName, direcName);
            return environmentVariablesFilesDirectory;
        }

        public string ConstructPathToSelfInFeatureNameDirectory(string direcName)
        {
            string destinationDirectory = automationsDirectory.GetPath();
            string environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, direcName);
            return environmentVariablesFilesDirectory;
        }
    }
}
