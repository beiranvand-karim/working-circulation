namespace cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory
{
    public class ProcessesMetaDataDirectory(IAutomationsDirectory automationsDirectory) : IProcessesMetaDataDirectory
    {
        private readonly IAutomationsDirectory automationsDirectory = automationsDirectory;

        public void Create()
        {
            var path = GetPath();
            Directory.CreateDirectory(path);
        }
        public string GetPath()
        {
            string directory = automationsDirectory.GetPath();
            string processesMetaDataDirectory = Path.Combine(directory, "processes-meta-data");
            return processesMetaDataDirectory;
        }
    }

    public interface IProcessesMetaDataDirectory
    {
        public string GetPath();
        public void Create();
    }
}