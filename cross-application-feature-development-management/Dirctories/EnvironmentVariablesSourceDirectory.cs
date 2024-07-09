using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Dirctories
{
    public class EnvironmentVariablesSourceDirectory(ICommandLineArgs commandLineArgs, IScriptsDirectory scriptsDirectory)
    :IEnvironmentVariablesSourceDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IScriptsDirectory scriptsDirectory = scriptsDirectory;

        public string GetName()
        {
            string environmentVariablesSourceDirectoryNameKey =
               commandLineArgs.GetKey("EnvironmentVariablesSourceDirectoryNameKey");

            string environmentVariablesSourceDirectoryName = commandLineArgs.GetByKey(environmentVariablesSourceDirectoryNameKey);

            string environmentVariablesSourceDirectory =
                Path.Combine(scriptsDirectory.GetName(), environmentVariablesSourceDirectoryName);

            return environmentVariablesSourceDirectory;
        }
    }
}