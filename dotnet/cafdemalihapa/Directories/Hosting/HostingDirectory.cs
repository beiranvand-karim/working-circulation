namespace cafdemalihapa.Directories.Hosting
{
    public static class HostingDirectory
    {
        public static string GetPath()
        {
            var hostingDirectoryPath = CommandLineArgs.GetByKey("--hosting-directory");
            return hostingDirectoryPath;
        }
    }
}