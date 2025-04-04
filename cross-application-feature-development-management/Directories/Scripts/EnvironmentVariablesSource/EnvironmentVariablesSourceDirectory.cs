namespace cross_application_feature_development_management.Directories.Scripts.EnvironmentVariablesSource
{
    public class EnvironmentVariablesSourceDirectory(
        CommandLineArgs commandLineArgs,
        ScriptsDirectory scriptsDirectory
        )
    {
        public string GetPath()
        {
            var environmentVariablesSourceDirectoryNameKey =
               commandLineArgs.GetKey("EnvironmentVariablesSourceDirectoryNameKey");

            var environmentVariablesSourceDirectoryName = CommandLineArgs.GetByKey(environmentVariablesSourceDirectoryNameKey);

            var environmentVariablesSourceDirectory =
                Path.Combine(scriptsDirectory.GetPath(), environmentVariablesSourceDirectoryName);

            return environmentVariablesSourceDirectory;
        }
    }
}