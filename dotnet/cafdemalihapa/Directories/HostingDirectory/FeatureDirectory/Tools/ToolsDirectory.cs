namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.Tools
{
    public class ToolsDirectory(
        FeatureDirectory featureDirectory
    )
    {
        public string GetPath()
        {
            var directoryName = "tools";
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