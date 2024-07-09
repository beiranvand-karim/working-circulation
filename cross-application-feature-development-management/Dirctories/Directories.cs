namespace cross_application_feature_development_management.Dirctories
{
    internal class Directories
    {
        public static void MoveAll(string featureNameDirectory, string targetDiretory)
        {
            DirectoryInfo dirInfo = new(featureNameDirectory);
            if (dirInfo.Exists == false)
                Directory.CreateDirectory(featureNameDirectory);

            List<string> MyMusicFiles = Directory
                            .GetFiles(targetDiretory, "*.*", SearchOption.AllDirectories).ToList();

            foreach (string file in MyMusicFiles)
            {
                FileInfo mFile = new FileInfo(file);
                if (new FileInfo(dirInfo + "/" + mFile.Name).Exists == false)
                {
                    mFile.MoveTo(dirInfo + "/" + mFile.Name);
                }
            }
        }

        public static void ReplaceFileNameWithPath(string receiverPath, string giverPath)
        {
            string fileName = Path.GetFileName(giverPath);
            string text = File.ReadAllText(receiverPath);
            text = text.Replace(fileName, giverPath);
            File.WriteAllText(receiverPath, text);
        }

        public static void CopyFileToDestinationDirectory(string file, string destinationDirectory)
        {
            string fileName = Path.GetFileName(file);
            string destFileName = Path.GetFileName(fileName);
            string destFilePathIncludingName = Path.Combine(destinationDirectory, destFileName);
            File.Copy(file, destFilePathIncludingName);
        }

        public static void CopyContentOfSourceDirectoryToDestinationDirectory(string sourceDirectory, string destinationDirectory)
        {
            foreach (string file in Directory.EnumerateFiles(sourceDirectory))
            {
                CopyFileToDestinationDirectory(file, destinationDirectory);
            }
        }
    }
}