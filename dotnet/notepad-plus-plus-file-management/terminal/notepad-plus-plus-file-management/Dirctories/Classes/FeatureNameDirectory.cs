using notepad_plus_plus_file_management.Dirctories.Interfaces;
using notepad_plus_plus_file_management.Interfaces;

namespace notepad_plus_plus_file_management.Dirctories.Classes
{
    public class FeatureNameDirectory(
            ICommandLineArgs commandLineArgs,
            IHostingDirectory hostingDirectory
        ) : IFeatureNameDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IHostingDirectory hostingDirectory = hostingDirectory;

        public void CreateSelf()
        {
            string featureNameDirectoryPath = GetPath();
            Directory.CreateDirectory(featureNameDirectoryPath);
        }

        public string GetPath()
        {
            string featureNameDirectoryNameKey = commandLineArgs.GetKey("FeatureNameKey");
            string featureNameDirectoryName = commandLineArgs.GetByKey(featureNameDirectoryNameKey);
            string hostingDirectoryName = hostingDirectory.GetName();
            string featureNameDirectoryPath = Path.Combine(hostingDirectoryName, featureNameDirectoryName);
            return featureNameDirectoryPath;
        }
    }
}