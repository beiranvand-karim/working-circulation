using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.BackEnd.BackEndSecondaryDirectory
{
    public class BackEndSecondaryDirectory(
            SecondaryApplication secondaryApplication,
            BackEndDirectory backEndDirectory
        )
    {
        public string GetName()
        {
            var backEndDirectoryName = backEndDirectory.GetName();
            var secondaryApplicationName = secondaryApplication.GetName();
            var name = $"{backEndDirectoryName}.{secondaryApplicationName}";
            return name;
        }

        public string GetPath()
        {
            var backEndDirectoryPath = backEndDirectory.GetPath();
            var name = GetName();

            var backEndSecondaryDirectoryPath = Path.Combine(backEndDirectoryPath, name);
            return backEndSecondaryDirectoryPath;
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
