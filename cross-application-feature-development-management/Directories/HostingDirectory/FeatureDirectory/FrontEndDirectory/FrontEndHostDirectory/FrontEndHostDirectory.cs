using cross_application_feature_development_management.Names;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndHostDirectory
{
    public class FrontEndHostDirectory(
            FrontEndDirectory frontEndDirectory,
            PrimaryApplication primaryApplication
        )
    {
        public string GetName()
        {
            var frontEndDirectoryName = frontEndDirectory.GetName();
            var primaryApplicationName = primaryApplication.GetName();
            var name = $"{frontEndDirectoryName}.{primaryApplicationName}";
            return name;
        }

        public string GetPath()
        {
            var frontEndDirectoryPath = frontEndDirectory.GetPath();
            var name = GetName();

            var frontEndHostDirectoryPath = Path.Combine(frontEndDirectoryPath, name);
            return frontEndHostDirectoryPath;
        }
    }
}