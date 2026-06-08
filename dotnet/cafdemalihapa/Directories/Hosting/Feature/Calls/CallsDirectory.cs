namespace cafdemalihapa.Directories.Hosting.Feature.Calls
{
    public class CallsDirectory()
    {
        public string GetPath()
        {
            var directoryName = "calls";
            var featureDirectoryPath = FeatureDirectory.GetPath();
            var notesAndMessages = Path.Combine(featureDirectoryPath, directoryName);
            return notesAndMessages;
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