namespace cross_application_feature_development_management.Directories
{
    public class TargetDirectory(
            WorkingCirculationDirectory workingCirculationDirectory
        )
    {
        public string CreatePathToSelf()
        {
            var environmentVariablesManagementDirectoryName = workingCirculationDirectory.GetName();
            var targetDirectoryPath = Path.Combine(environmentVariablesManagementDirectoryName, "target");
            return targetDirectoryPath;
        }
    }
}