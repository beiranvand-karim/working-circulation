using cafdemalihapa.Directories.Repository.DotnetDirectory;
using cafdemalihapa.Directories.Repository.DotnetDirectory.Cafdemalihapa;

namespace cafdemalihapa.Directories.Repository.DotnetDirectory.Cafdemalihapa.Scripts
{
    public class ScriptsDirectory
    (
        CafdemalihapaDirectory cafdemalihapaDirectory
    )
    {
        public string GetPath()
        {
            var cafdemalihapaDirectoryPath = cafdemalihapaDirectory.GetPath();
            var scriptsDirectoryPath = Path.Combine(cafdemalihapaDirectoryPath, "scripts");
            return scriptsDirectoryPath;
        }
    }
}