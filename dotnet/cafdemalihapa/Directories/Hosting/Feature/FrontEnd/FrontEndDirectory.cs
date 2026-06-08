namespace cafdemalihapa.Directories.Hosting.Feature.FrontEnd
{
    public class FrontEndDirectory()
    {
        public string GetName()
        {
            return "fend";
        }
        public string GetPath()
        {
            var directoryName = GetName();
            var featureDirectoryPath = FeatureDirectory.GetPath();
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