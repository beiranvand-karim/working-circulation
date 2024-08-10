namespace cross_application_feature_development_management.Dirctories.Interfaces
{
    public interface IBatchScriptsDicrectory
    {
        public void ReplaceFileNamesWithPaths();

        public string ConstructPathToSelfInTargetDirectory(string direcName);
        public string CreatePathToSelfInFeatureNameDirector();
        public void CopyContentToFeaureNameDicrectory();
        public void CopyContentToTargetDicrectory();
        public string CreatePathToSelfInScriptsDirectory();
    }
}