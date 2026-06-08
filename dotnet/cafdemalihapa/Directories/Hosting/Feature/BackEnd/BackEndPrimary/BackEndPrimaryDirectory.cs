using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.Hosting.Feature.BackEnd.BackEndPrimary
{
    public class BackEndPrimaryDirectory(
            BackEndDirectory backEndDirectory,
            PrimaryApplication primaryApplication
        )
    {
        public string GetName()
        {
            var backEndDirectoryName = backEndDirectory.GetName();
            var primaryApplicationName = primaryApplication.GetName();
            var name = $"{backEndDirectoryName}.{primaryApplicationName}";
            return name;
        }

        public string GetPath()
        {
            var backEndDirectoryPath = backEndDirectory.GetPath();
            var name = GetName();

            var backEndPrimaryDirectoryPath = Path.Combine(backEndDirectoryPath, name);
            return backEndPrimaryDirectoryPath;
        }

        public void Create()
        {
            var path = GetPath();
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
