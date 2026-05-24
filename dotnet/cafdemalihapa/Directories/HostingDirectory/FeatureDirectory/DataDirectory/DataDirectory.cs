namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.DataDirectory
{
    public class DataDirectory
    (
        FeatureDirectory featureDirectory
    )
    {
        public string GetName()
        {
            return "data";
        }
        public string GetPath()
        {
            var directoryName = GetName();
            var featureDirectoryPath = featureDirectory.GetPath();
            var dataDirectory = Path.Combine(featureDirectoryPath, directoryName);
            return dataDirectory;
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
