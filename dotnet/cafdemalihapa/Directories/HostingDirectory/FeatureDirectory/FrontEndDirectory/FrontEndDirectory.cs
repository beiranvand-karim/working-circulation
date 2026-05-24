namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory
{
    public class FrontEndDirectory(
            FeatureDirectory featureDirectory
        )
    {
        public string GetName()
        {
            return "fend";
        }
        public string GetPath()
        {
            var directoryName = GetName();
            var featureDirectoryPath = featureDirectory.GetPath();
            var frontEndDirectoryPath = Path.Combine(featureDirectoryPath, directoryName);
            return frontEndDirectoryPath;
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