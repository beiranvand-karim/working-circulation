namespace cafdemalihapa.Directories.Hosting
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