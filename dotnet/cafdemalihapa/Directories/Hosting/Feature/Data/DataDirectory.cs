namespace cafdemalihapa.Directories.Hosting.Feature.Data
{
    public class DataDirectory()
    {
        public string GetName()
        {
            return "data";
        }
        public string GetPath()
        {
            var directoryName = GetName();
            var featureDirectoryPath = FeatureDirectory.GetPath();
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
