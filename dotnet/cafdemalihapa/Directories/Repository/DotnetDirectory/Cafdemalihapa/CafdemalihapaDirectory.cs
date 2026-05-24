namespace cafdemalihapa.Directories.Repository.DotnetDirectory.Cafdemalihapa
{
    public class CafdemalihapaDirectory
    (
        DotnetDirectory dotnetDirectory
    )
    {
        public string GetPath()
        {
            var dotnetDirectoryPath = dotnetDirectory.GetPath();
            var cafdemalihapaDirectoryPath = Path.Combine(dotnetDirectoryPath, "cafdemalihapa");
            return cafdemalihapaDirectoryPath;
        }
    }
}