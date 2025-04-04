namespace cross_application_feature_development_management.Directories.Scripts
{
    public class ScriptsDirectory(
            CommandLineArgs commandLineArgs
        )
    {
        public string GetPath()
        {
            var scriptsDirectoryNameKey = commandLineArgs.GetKey("ScriptsDirectoryNameKey");
            var scriptsDirectoryName = CommandLineArgs.GetByKey(scriptsDirectoryNameKey);
            return scriptsDirectoryName;
        }
    }
}