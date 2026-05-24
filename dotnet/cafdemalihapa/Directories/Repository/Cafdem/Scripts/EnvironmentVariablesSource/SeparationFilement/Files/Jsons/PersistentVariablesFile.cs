namespace cafdemalihapa.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.Files.Jsons
{
    public class PersistentVariablesFile(
        SeparationFilementDirectory separationFilementDirectory
    )
    {
        public string GetName()
        {
            return "persistent-variables.json";
        }

        public string GetPath()
        {
            var name = GetName();
            return Path.Combine(separationFilementDirectory.GetPath(), name);
        }
    }
}