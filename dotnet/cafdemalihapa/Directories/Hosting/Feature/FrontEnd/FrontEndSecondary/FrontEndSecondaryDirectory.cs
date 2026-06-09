using cafdemalihapa.Files;
using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndSecondary
{
    public class FrontEndSecondaryDirectory(
            SecondaryApplication secondaryApplication,
            FrontEndDirectory frontEndDirectory
        )
    {
        public string GetName()
        {
            var frontEndDirectoryName = frontEndDirectory.GetName();
            var secondaryApplicationName = secondaryApplication.GetName();
            var name = $"{frontEndDirectoryName}.{secondaryApplicationName}";
            return name;
        }

        public string GetPath()
        {
            var frontEndDirectoryPath = frontEndDirectory.GetPath();
            var name = GetName();

            var frontEndSecondaryDirectoryPath = Path.Combine(frontEndDirectoryPath, name);
            return frontEndSecondaryDirectoryPath;
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