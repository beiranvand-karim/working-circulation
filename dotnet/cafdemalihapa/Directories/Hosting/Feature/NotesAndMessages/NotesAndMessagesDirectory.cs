using cafdemalihapa.Files;

namespace cafdemalihapa.Directories.Hosting.Feature.NotesAndMessages
{
    public class NotesAndMessagesDirectory(
            FeatureDirectory featureDirectory
        )
    {
        public string GetPath()
        {
            var directoryName = "notes and messages";
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

        public void CreateFiles()
        {
            var path = GetPath();
            FileService.CreateNumberedFiles(path);
        }
    }
}