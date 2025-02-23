namespace cross_application_feature_development_management.Directories.Interfaces
{
    public interface IDirectories
    {
        public void ReplaceFileNameWithPath(string receiverPath, string giverPath);
        public void ReplaceFileNameWithPath(string receiverPath, string repalcee, string replacer);
        public void CopyFileToDestinationDirectory(string file, string destinationDirectory);
        public void CopyContentOfSourceDirectoryToDestinationDirectory(string sourceDirectory, string destinationDirectory);

    }
}