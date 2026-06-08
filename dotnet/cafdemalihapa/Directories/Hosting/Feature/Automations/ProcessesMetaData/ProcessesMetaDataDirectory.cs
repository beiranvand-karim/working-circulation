namespace cafdemalihapa.Directories.Hosting.Feature.Automations.ProcessesMetaData
{
    public class ProcessesMetaDataDirectory(
         AutomationsDirectory automationsDirectory
        )
    {
        public void Create()
        {
            var path = GetPath();
            Directory.CreateDirectory(path);
        }
        public string GetPath()
        {
            var directory = automationsDirectory.GetPath();
            var processesMetaDataDirectory = Path.Combine(directory, "processes-meta-data");
            return processesMetaDataDirectory;
        }
    }
}