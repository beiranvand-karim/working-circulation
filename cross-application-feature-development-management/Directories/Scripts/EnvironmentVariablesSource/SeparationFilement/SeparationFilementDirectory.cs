namespace cross_application_feature_development_management.Directories.Scripts.EnvironmentVariablesSource.SeparationFilement
{
    public class SeparationFilementDirectory(
        EnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory
    )
    {
        public string GetPath()
        {
            return Path.Combine(environmentVariablesSourceDirectory.GetName(), "separation-filement");
        }
    }
}