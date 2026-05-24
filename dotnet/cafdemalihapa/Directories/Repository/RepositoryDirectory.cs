namespace cafdemalihapa.Directories.Repository
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