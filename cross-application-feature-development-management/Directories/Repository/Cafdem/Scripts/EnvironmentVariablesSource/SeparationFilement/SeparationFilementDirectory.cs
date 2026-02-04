namespace cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement
{
    public class SeparationFilementDirectory(
        EnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory
    )
    {
        public string GetPath()
        {
            return Path.Combine(environmentVariablesSourceDirectory.GetPath(), "separation-filement");
        }
    }
}