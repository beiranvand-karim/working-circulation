
namespace EnvironmentVariablesManagement
{
    internal class WorkingCirculationDirectory
    {
        public static string GetName()
        {
            string workingCirculationDirectoryName = CreatePath();

            string environmeentVariablesManagementDirectoryName =
                Path.Combine(workingCirculationDirectoryName, "EnvironmeentVariablesManagement");

            return environmeentVariablesManagementDirectoryName;
        }

        public static string CreatePath()
        {
            string repositoryDirectoryNameKey = "--repository-directory";
            string workingCirculationDirectoryName =
                Path.Combine(CommandLineArgs.GetByKey(repositoryDirectoryNameKey), "WorkingCirculation");
            return workingCirculationDirectoryName;         
        }   
    }
}
