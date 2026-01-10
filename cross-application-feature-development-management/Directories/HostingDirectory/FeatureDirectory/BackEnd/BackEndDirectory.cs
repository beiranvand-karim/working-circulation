namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.BackEnd
{
    public class BackEndDirectory
    (
        FeatureDirectory featureDirectory
    )
    {
        public string GetPath()
        {
            var directoryName = "bend";
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