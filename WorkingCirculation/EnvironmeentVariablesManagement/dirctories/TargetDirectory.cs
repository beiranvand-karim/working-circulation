
namespace EnvironmentVariablesManagement
{
    internal class TargetDirectory
    {
        public static string CreatePathToSelf()
        {
            string environmeentVariablesManagementDirectoryName = WorkingCirculationDirectory.GetName();
            string targetDirectoryPath = Path.Combine(environmeentVariablesManagementDirectoryName, "target");
            return targetDirectoryPath;
        }        
    }
}