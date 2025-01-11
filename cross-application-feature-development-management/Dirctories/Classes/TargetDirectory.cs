using cross_application_feature_development_management.Dirctories.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Classes
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