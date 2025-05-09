namespace cross_application_feature_development_management.Directories.Scripts
{
    public class ScriptsDirectory
    {
        public string GetPath()
        {
            var scriptsDirectoryPath = CommandLineArgs.GetByKey("--scripts-directory");
            return scriptsDirectoryPath;
        }
    }
}