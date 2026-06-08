using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.Hosting.Feature.BackEnd.BackEndSecondary
{
    public class BackEndSecondaryDirectory(
            SecondaryApplication secondaryApplication
        )
    {
        public string GetName()
        {
            var backEndDirectoryName = BackEndDirectory.GetName();
            var secondaryApplicationName = secondaryApplication.GetName();
            var name = $"{backEndDirectoryName}.{secondaryApplicationName}";
            return name;
        }

        public string GetPath()
        {
            var backEndDirectoryPath = BackEndDirectory.GetPath();
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
