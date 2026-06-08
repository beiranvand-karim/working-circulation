using cafdemalihapa.Files;
using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndHost
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