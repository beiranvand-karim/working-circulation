namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.Calls
{
    public class CallsDirectory
    (
        FeatureDirectory featureDirectory
    )
    {
        public string GetPath()
        {
            var directoryName = "calls";
            var featureDirectoryPath = featureDirectory.GetPath();
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