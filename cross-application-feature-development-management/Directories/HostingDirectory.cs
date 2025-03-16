namespace cross_application_feature_development_management.Directories
{
    public class HostingDirectory(
            CommandLineArgs commandLineArgs
        )
    {
        public string GetName()
        {
            var hostingDirectoryNameKey = commandLineArgs.GetKey("HostingDirectoryNameKey");
            var hostingDirectoryName = CommandLineArgs.GetByKey(hostingDirectoryNameKey);
            return hostingDirectoryName;
        }
    }
}