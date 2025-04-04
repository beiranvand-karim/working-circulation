namespace cross_application_feature_development_management.Directories.HostingDirectory
{
    public class HostingDirectory(
            CommandLineArgs commandLineArgs
        )
    {
        public string GetPath()
        {
            var hostingDirectoryNameKey = commandLineArgs.GetKey("HostingDirectoryNameKey");
            var hostingDirectoryName = CommandLineArgs.GetByKey(hostingDirectoryNameKey);
            return hostingDirectoryName;
        }
    }
}