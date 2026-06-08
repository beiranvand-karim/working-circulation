namespace cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.Files.Jsons
{
    public class PersistentVariablesFile(
EnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory
    )
    {
        public string GetName()
        {
            return "persistent-variables.json";
        }

        public string GetPath()
        {
            var name = GetName();
            return Path.Combine(environmentVariablesSourceDirectory.GetPath(), name);
        }
    }
}