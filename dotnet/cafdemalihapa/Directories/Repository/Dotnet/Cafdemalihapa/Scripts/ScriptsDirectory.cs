using cafdemalihapa.Directories.Repository.Dotnet;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa;

namespace cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts
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