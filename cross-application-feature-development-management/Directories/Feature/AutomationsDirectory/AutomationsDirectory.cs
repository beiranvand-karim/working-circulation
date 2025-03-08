namespace cross_application_feature_development_management.Directories.Feature.AutomationsDirectory
{
    public class AutomationsDirectory(
            FeatureNameDirectory featureNameDirectory
        )
    {
        public void Create()
        {
            var path = GetPath();
            Directory.CreateDirectory(path);
        }
        public string GetPath()
        {
            var directory = featureNameDirectory.GetPath();
            var automationsDirectory = Path.Combine(directory, "automations");
            return automationsDirectory;
        }
    }
}