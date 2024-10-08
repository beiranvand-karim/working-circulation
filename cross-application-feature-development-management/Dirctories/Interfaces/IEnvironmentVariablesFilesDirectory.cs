namespace cross_application_feature_development_management.Dirctories.Interfaces
{
    public interface IEnvironmentVariablesFilesDirectory
    {
        public void CopyContentToFeatureNameDicrectory();
        public void CopyContentToTargetDicrectory();
        public string CreatePathToSelfInScriptsDirectory();
        public string CreatePathToSelfInFeatureNameDirectory();
        public string CreatePathToSelfInTargetDirectory();
        public string GetName();

    }
}