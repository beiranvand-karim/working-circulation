namespace cross_application_feature_development_management.Dirctories.Interfaces
{
    public interface IPowerShellScriptsDirectory
    {
        public void ReplaceFileNamesWithPaths();
        public void CopyContentToFeatureNameDicrectory();
        public void CopyContentToTargetDicrectory();
        public string ConstructPathToSelfInScriptsDirectory(string direcName);
        public string ConstructPathToSelfInFeatureNameDirectory(string direcName);
        public string ConstructPathToSelfInTargetDirectory(string direcName);
        public string ConstructPathToSelfInScriptsDirectory();
        public string ConstructPathToSelfInTargetDirectory();
    }
}