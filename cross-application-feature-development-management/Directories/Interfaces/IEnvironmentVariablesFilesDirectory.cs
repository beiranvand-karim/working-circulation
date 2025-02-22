namespace cross_application_feature_development_management.Directories.Interfaces
{
    public interface IEnvironmentVariablesFilesDirectory
    {
        public void CopyContentToFeatureNameDirectory();
        public void CopyContentToTargetDirectory();
        public string CreatePathToSelfInScriptsDirectory();
        public string CreatePathToSelfInFeatureNameDirectory();
        public string CreatePathToSelfInTargetDirectory();
        public string GetName();

    }
}