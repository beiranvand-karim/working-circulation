namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory
{
    public class AutomationsDirectory(
            FeatureDirectory featureDirectory
        )
    {
        public void Create()
        {
            var path = GetPath();
            Directory.CreateDirectory(path);
        }
        public string GetPath()
        {
            var directory = featureDirectory.GetPath();
            var automationsDirectory = Path.Combine(directory, "automations");
            return automationsDirectory;
        }
    }
}