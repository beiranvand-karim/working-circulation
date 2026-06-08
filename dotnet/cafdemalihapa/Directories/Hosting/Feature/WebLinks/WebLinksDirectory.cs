namespace cafdemalihapa.Directories.Hosting.Feature.WebLinks
{
    public class WebLinksDirectory()
    {
        public string GetPath()
        {
            var directoryName = "web links";
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