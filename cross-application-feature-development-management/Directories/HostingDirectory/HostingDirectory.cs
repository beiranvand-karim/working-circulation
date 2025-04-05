namespace cross_application_feature_development_management.Directories.HostingDirectory
{
    public class HostingDirectory
    {
        public string GetPath()
        {
            var hostingDirectoryPath = CommandLineArgs.GetByKey("--hosting-directory");
            return hostingDirectoryPath;
        }
    }
}