using cross_application_feature_development_management.Dirctories.Feature.Interfaces;
using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Feature.Classes
{
    public class FeatureDirectory : IFeatureDirectory
    {
        private readonly ICommandLineArgs _commandLineArgs;
        private readonly IHostingDirectory _hostingDirectory;

        private String? address;

        public FeatureDirectory(
            ICommandLineArgs commandLineArgs,
            IHostingDirectory hostingDirectory
            )
        {
            _commandLineArgs = commandLineArgs;
            _hostingDirectory = hostingDirectory;
            Address = GetPath();
        }

        public string? Address { get => address; set => address = value; }

        public void Create()
        {
            string featureDirectoryPath = GetPath();
            Directory.CreateDirectory(featureDirectoryPath);
        }

        public string GetPath()
        {
            string featureDirectoryNameKey = _commandLineArgs.GetKey("FeatureNameKey");
            string featureNameDirectoryName = _commandLineArgs.GetByKey(featureDirectoryNameKey);
            string hostingDirectoryName = _hostingDirectory.GetName();
            string featureNameDirectoryPath = Path.Combine(hostingDirectoryName, featureNameDirectoryName);
            return featureNameDirectoryPath;
        }
    }
}