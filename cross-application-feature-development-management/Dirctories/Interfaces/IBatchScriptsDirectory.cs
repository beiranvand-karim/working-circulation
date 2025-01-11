namespace cross_application_feature_development_management.Dirctories.Interfaces
{
    public interface IBatchScriptsDirectory
    {
        public void ReplaceFileNamesWithPaths();

        public string ConstructPathToSelfInTargetDirectory(string direcName);
        public string CreatePathToSelfInFeatureNameDirector();
        public void CopyContentToFeatureNameDirectory();
        public void CopyContentToTargetDirectory();
        public string CreatePathToSelfInScriptsDirectory();
    }
}