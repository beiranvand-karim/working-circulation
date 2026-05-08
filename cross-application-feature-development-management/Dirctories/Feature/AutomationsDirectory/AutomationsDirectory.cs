using cross_application_feature_development_management.Dirctories.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory
{
    public interface IAutomationsDirectory
    {
        public string GetPath();
        public void Create();
    }


    public class AutomationsDirectory(
            IFeatureNameDirectory featureNameDirectory
        ) : IAutomationsDirectory
    {
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;

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