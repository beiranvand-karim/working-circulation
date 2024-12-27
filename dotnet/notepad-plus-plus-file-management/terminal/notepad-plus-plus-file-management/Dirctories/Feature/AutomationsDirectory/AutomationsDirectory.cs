using notepad_plus_plus_file_management.Dirctories.Interfaces;

namespace notepad_plus_plus_file_management.Dirctories.Feature.AutomationsDirectory
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
            string directory = featureNameDirectory.GetPath();
            string automationsDirectory = Path.Combine(directory, "automations");
            return automationsDirectory;
        }
    }
}