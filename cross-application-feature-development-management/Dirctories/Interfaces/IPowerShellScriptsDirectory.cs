namespace cross_application_feature_development_management.Dirctories.Interfaces
{
    public interface IPowerShellScriptsDirectory
    {
        public void ReplaceFileNamesWithPaths();
        public void CopyContentToFeatureNameDicrectory();
        public string ConstructPathToSelfInScriptsDirectory(string direcName);
        public string ConstructPathToSelfInFeatureNameDirectory(string direcName);
    }
}