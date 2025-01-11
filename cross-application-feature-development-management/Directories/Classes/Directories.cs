using cross_application_feature_development_management.Directories.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Classes
{
    public class Directories(ILogger<Directories> logger) : IDirectories
    {
        private readonly ILogger<Directories> logger = logger;

        public void ReplaceFileNameWithPath(string receiverPath, string giverPath)
        {
            var fileName = Path.GetFileName(giverPath);
            var text = File.ReadAllText(receiverPath);
            text = text.Replace(fileName, giverPath);
            File.WriteAllText(receiverPath, text);
        }

        public void ReplaceFileNameWithPath(string receiverPath, string repalcee, string replacer)
        {
            var text = File.ReadAllText(receiverPath);
            text = text.Replace(repalcee, replacer);
            File.WriteAllText(receiverPath, text);
        }

        public void CopyFileToDestinationDirectory(string file, string destinationDirectory)
        {
            var fileName = Path.GetFileName(file);
            var destFileName = Path.GetFileName(fileName);
            var destFilePathIncludingName = Path.Combine(destinationDirectory, destFileName);
            File.Copy(file, destFilePathIncludingName);
        }

        public void CopyContentOfSourceDirectoryToDestinationDirectory(string sourceDirectory, string destinationDirectory)
        {
            foreach (var file in Directory.EnumerateFiles(sourceDirectory))
            {
                CopyFileToDestinationDirectory(file, destinationDirectory);
            }
        }
    }
}