using cafdemalihapa.Files;
using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndGuestDirectory
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

        public void Create()
        {
            var path = GetPath();
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void CreateFiles()
        {
            var path = GetPath();
            FileService.CreateNumberedFiles(path);
        }
    }
}