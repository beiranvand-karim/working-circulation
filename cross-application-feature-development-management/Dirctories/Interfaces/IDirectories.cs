namespace cross_application_feature_development_management.Dirctories.Interfaces
{
    public interface IDirectories
    {
        public void ReplaceFileNameWithPath(string receiverPath, string giverPath);
        public void CopyFileToDestinationDirectory(string file, string destinationDirectory);
        public void CopyContentOfSourceDirectoryToDestinationDirectory(string sourceDirectory, string destinationDirectory);

    }
}