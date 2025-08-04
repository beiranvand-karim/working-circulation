namespace cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts
{
    public class ScriptsDirectory
    (
        CafdemDirectory cafdemDirectory
    )
    {
        public string GetPath()
        {
            var cafdemDirectoryPath = cafdemDirectory.GetPath();
            var scriptsDirectoryPath = Path.Combine(cafdemDirectoryPath, "scripts");
            return scriptsDirectoryPath;
        }
    }
}