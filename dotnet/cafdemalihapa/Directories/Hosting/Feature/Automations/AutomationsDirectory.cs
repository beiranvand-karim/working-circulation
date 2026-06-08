namespace cafdemalihapa.Directories.Hosting.Feature.Automations
{
    public class AutomationsDirectory()
    {
        public void Create()
        {
            var path = GetPath();
            Directory.CreateDirectory(path);
        }
        public string GetPath()
        {
            var directory = FeatureDirectory.GetPath();
            var automationsDirectory = Path.Combine(directory, "automations");
            return automationsDirectory;
        }
    }
}