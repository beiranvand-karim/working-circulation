
namespace EnvironmentVariablesManagement
{
    internal class TargetDirectory
    {
        public static string CreatePathToSelf()
        {
            string environmeentVariablesManagementDirectoryName = Directories.GetEnvironmeentVariablesManagementDirectoryName();
            string targetDirectoryPath = Path.Combine(environmeentVariablesManagementDirectoryName, "target");
            return targetDirectoryPath;
        }        
    }
}