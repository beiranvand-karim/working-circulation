namespace cafdemalihapa.Directories.Hosting.Feature.BackEnd
{
    public class BackEndDirectory
    (
        FeatureDirectory featureDirectory
    )
    {
        public string GetName()
        {
            return "bend";
        }
        public string GetPath()
        {
            var directoryName = GetName();
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