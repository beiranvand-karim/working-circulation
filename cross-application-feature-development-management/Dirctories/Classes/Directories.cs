
using cross_application_feature_development_management.Dirctories.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Dirctories.Classes
{
    public class Directories(ILogger<Directories> logger) : IDirectories
    {
        private readonly ILogger<Directories> logger = logger;

        public void ReplaceFileNameWithPath(string receiverPath, string giverPath)
        {
            string fileName = Path.GetFileName(giverPath);
            string text = File.ReadAllText(receiverPath);
            text = text.Replace(fileName, giverPath);
            File.WriteAllText(receiverPath, text);
        }

        public void ReplaceFileNameWithPath(string receiverPath, string repalcee, string replacer)
        {
            string text = File.ReadAllText(receiverPath);
            text = text.Replace(repalcee, replacer);
            File.WriteAllText(receiverPath, text);
        }

        public void CopyFileToDestinationDirectory(string file, string destinationDirectory)
        {
            string fileName = Path.GetFileName(file);
            string destFileName = Path.GetFileName(fileName);
            string destFilePathIncludingName = Path.Combine(destinationDirectory, destFileName);
            File.Copy(file, destFilePathIncludingName);
        }

        public void CopyContentOfSourceDirectoryToDestinationDirectory(string sourceDirectory, string destinationDirectory)
        {
            foreach (string file in Directory.EnumerateFiles(sourceDirectory))
            {
                CopyFileToDestinationDirectory(file, destinationDirectory);
            }
        }
    }
}