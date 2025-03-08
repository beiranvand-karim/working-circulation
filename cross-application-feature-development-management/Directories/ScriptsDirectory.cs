namespace cross_application_feature_development_management.Directories
{
    public class ScriptsDirectory(
            CommandLineArgs commandLineArgs
        )
    {
        public string GetName()
        {
            var scriptsDirectoryNameKey = commandLineArgs.GetKey("ScriptsDirectoryNameKey");
            var scriptsDirectoryName = CommandLineArgs.GetByKey(scriptsDirectoryNameKey);
            return scriptsDirectoryName;
        }
    }
}