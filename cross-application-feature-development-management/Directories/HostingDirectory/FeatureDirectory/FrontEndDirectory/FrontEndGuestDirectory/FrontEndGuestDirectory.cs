using cross_application_feature_development_management.Names;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndGuestDirectory
{
    public class FrontEndGuestDirectory(
            SecondaryApplication secondaryApplication,
            FrontEndDirectory frontEndDirectory
        )
    {
        public string GetName()
        {
            var frontEndDirectoryName = frontEndDirectory.GetName();
            var guestApplication = secondaryApplication.GetName();
            var name = $"{frontEndDirectoryName}.{guestApplication}";
            return name;
        }

        public string GetPath()
        {
            var frontEndDirectoryPath = frontEndDirectory.GetPath();
            var name = GetName();

            var frontEndGuestDirectoryPath = Path.Combine(frontEndDirectoryPath, name);
            return frontEndGuestDirectoryPath;
        }
    }
}