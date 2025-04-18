using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Repository
{
    public class RepositoryDirectory
    (
        ILogger<RepositoryDirectory> logger
    )
    {
        public string GetPath()
        {
            var repositoryDirectoryPath = CommandLineArgs.GetByKey("--repository-directory");
            return repositoryDirectoryPath;
        }
    }
}