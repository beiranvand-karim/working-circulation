namespace cross_application_feature_development_management.Directories.Interfaces
{
    public interface IPowerShellScriptsDirectory
    {
        public void ReplaceFileNamesWithPaths();
        public void CopyContentToFeatureNameDirectory();
        public string ConstructPathToSelfInScriptsDirectory(string direcName);
        public string ConstructPathToSelfInFeatureNameDirectory(string direcName);
    }
}