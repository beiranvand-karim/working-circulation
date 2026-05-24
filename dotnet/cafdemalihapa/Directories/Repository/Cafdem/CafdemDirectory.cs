namespace cafdemalihapa.Directories.Repository.Cafdem
{
    public class CafdemDirectory
    (
        RepositoryDirectory repositoryDirectory
    )
    {
        public string GetPath()
        {
            var repositoryDirectoryPath = repositoryDirectory.GetPath();
            var cafdemDirectoryPath = Path.Combine(repositoryDirectoryPath, "cross-application-feature-development-management");
            return cafdemDirectoryPath;
        }
    }
}