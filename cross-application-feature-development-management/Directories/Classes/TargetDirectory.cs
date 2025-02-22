using cross_application_feature_development_management.Directories.Interfaces;

namespace cross_application_feature_development_management.Directories.Classes
{
    public class TargetDirectory(IWorkingCirculationDirectory workingCirculationDirectory) : ITargetDirectory
    {
        private readonly IWorkingCirculationDirectory workingCirculationDirectory = workingCirculationDirectory;

        public string CreatePathToSelf()
        {
            var environmentVariablesManagementDirectoryName = workingCirculationDirectory.GetName();
            var targetDirectoryPath = Path.Combine(environmentVariablesManagementDirectoryName, "target");
            return targetDirectoryPath;
        }
    }
}