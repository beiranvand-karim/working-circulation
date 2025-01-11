using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Classes
{
    public class WorkingCirculationDirectory(ICommandLineArgs commandLineArgs) : IWorkingCirculationDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetName()
        {
            var workingCirculationDirectoryName = CreatePath();

            var environmentVariablesManagementDirectoryName =
                Path.Combine(workingCirculationDirectoryName, "EnvironmeentVariablesManagement");

            return environmentVariablesManagementDirectoryName;
        }

        public string CreatePath()
        {
            const string repositoryDirectoryNameKey = "--repository-directory";
            var workingCirculationDirectoryName =
                Path.Combine(commandLineArgs.GetByKey(repositoryDirectoryNameKey), "WorkingCirculation");
            return workingCirculationDirectoryName;
        }
    }
}
