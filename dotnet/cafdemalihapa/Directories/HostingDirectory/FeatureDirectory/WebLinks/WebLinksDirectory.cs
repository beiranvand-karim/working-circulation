namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.WebLinks
{
    public class WebLinksDirectory
    (
        FeatureDirectory featureDirectory
    )
    {
        public string GetPath()
        {
            var directoryName = "web links";
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