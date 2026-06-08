namespace cafdemalihapa.Directories.Hosting.Feature.Tools
{
    public class ToolsDirectory()
    {
        public string GetPath()
        {
            var directoryName = "tools";
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