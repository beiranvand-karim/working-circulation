namespace cafdemalihapa.Directories.Repository.DotnetDirectory
{
    public class DotnetDirectory
    (
        RepositoryDirectory repositoryDirectory
    )
    {
        public string GetPath()
        {
            var repositoryDirectoryPath = repositoryDirectory.GetPath();
            return Path.Combine(repositoryDirectoryPath, "dotnet");
        }
    }
}
