
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class Directories 
    {
        public static void CopyFileToDestinationDirectory(string file, string destinationDirectory)
        {
            string fileName = Path.GetFileName(file);
            string destFileName = Path.GetFileName(fileName);
            string destFilePathIncludingName = Path.Combine(destinationDirectory, destFileName);
            File.Copy(file, destFilePathIncludingName);
        }

        public static void CopyContentOfSourceDireectoryToDestinationDirectory(string sourceDirectory, string destinationDirectory)
        {
            foreach (string file in Directory.EnumerateFiles(sourceDirectory))
            {
                CopyFileToDestinationDirectory(file, destinationDirectory);
            }
        }     
    }
}