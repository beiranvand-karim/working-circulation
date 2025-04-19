namespace cross_application_feature_development_management.Directories.Repository
{
    public class RepositoryDirectory
    {
        public string GetPath()
        {
            var repositoryDirectoryPath = CommandLineArgs.GetByKey("--repository-directory");
            return repositoryDirectoryPath;
        }
    }
}