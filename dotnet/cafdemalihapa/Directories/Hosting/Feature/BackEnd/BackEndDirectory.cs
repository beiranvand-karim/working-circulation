namespace cafdemalihapa.Directories.Hosting.Feature.BackEnd
{
    public static class BackEndDirectory
    {
        public static string GetName()
        {
            return "bend";
        }
        public static string GetPath()
        {
            var directoryName = GetName();
            var featureDirectoryPath = FeatureDirectory.GetPath();
            var notesAndMessages = Path.Combine(featureDirectoryPath, directoryName);
            return notesAndMessages;
        }
        public static void Create()
        {
            var path = GetPath();
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}