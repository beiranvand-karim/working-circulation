using cross_application_feature_development_management.Dirctories.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Classes
{
    public class TargetDirectory(IWorkingCirculationDirectory workingCirculationDirectory) : ITargetDirectory
    {
        private readonly IWorkingCirculationDirectory workingCirculationDirectory = workingCirculationDirectory;

        public string CreatePathToSelf()
        {
            string environmeentVariablesManagementDirectoryName = workingCirculationDirectory.GetName();
            string targetDirectoryPath = Path.Combine(environmeentVariablesManagementDirectoryName, "target");
            return targetDirectoryPath;
        }
    }
}