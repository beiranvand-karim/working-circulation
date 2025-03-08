namespace cross_application_feature_development_management.Directories
{
    public class WorkingCirculationDirectory(
            CommandLineArgs commandLineArgs
        )
    {
        public string GetName()
        {
            var workingCirculationDirectoryName = CreatePath();

            var environmentVariablesManagementDirectoryName =
                Path.Combine(workingCirculationDirectoryName, "EnvironmeentVariablesManagement");

            return environmentVariablesManagementDirectoryName;
        }

        private string CreatePath()
        {
            const string repositoryDirectoryNameKey = "--repository-directory";
            var workingCirculationDirectoryName =
                Path.Combine(CommandLineArgs.GetByKey(repositoryDirectoryNameKey), "WorkingCirculation");
            return workingCirculationDirectoryName;
        }
    }
}
