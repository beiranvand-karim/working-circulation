namespace cross_application_feature_development_management.Directories
{
    public class EnvironmentVariablesSourceDirectory(
        CommandLineArgs commandLineArgs,
        ScriptsDirectory scriptsDirectory
        )
    {
        public string GetName()
        {
            var environmentVariablesSourceDirectoryNameKey =
               commandLineArgs.GetKey("EnvironmentVariablesSourceDirectoryNameKey");

            var environmentVariablesSourceDirectoryName = CommandLineArgs.GetByKey(environmentVariablesSourceDirectoryNameKey);

            var environmentVariablesSourceDirectory =
                Path.Combine(scriptsDirectory.GetName(), environmentVariablesSourceDirectoryName);

            return environmentVariablesSourceDirectory;
        }
    }
}