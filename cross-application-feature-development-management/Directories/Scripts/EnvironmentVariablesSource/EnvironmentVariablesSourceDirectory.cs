namespace cross_application_feature_development_management.Directories.Scripts.EnvironmentVariablesSource
{
    public class EnvironmentVariablesSourceDirectory(
        ScriptsDirectory scriptsDirectory
        )
    {
        public string GetPath()
        {
            var environmentVariablesSourceDirectory =
                Path.Combine(scriptsDirectory.GetPath(), "environment-variables-source");

            return environmentVariablesSourceDirectory;
        }
    }
}