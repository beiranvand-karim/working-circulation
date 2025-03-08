namespace cross_application_feature_development_management.Directories
{
    public class HostingDirectory(
            CommandLineArgs commandLineArgs
        )
    {
        public string GetName()
        {
            var hostingDirectoryNameKey = commandLineArgs.GetKey("HostingDirectoryNameKey");
            var hostingDirectoryName = commandLineArgs.GetByKey(hostingDirectoryNameKey);
            return hostingDirectoryName;
        }
    }
}