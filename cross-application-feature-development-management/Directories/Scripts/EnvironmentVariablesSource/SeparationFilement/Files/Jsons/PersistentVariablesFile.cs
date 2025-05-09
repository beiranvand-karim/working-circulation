namespace cross_application_feature_development_management.Directories.Scripts.EnvironmentVariablesSource.SeparationFilement.Files.Jsons
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
            return Path.Combine(separationFilementDirectory.GetPath(), "persistent-variables.json");
        }
    }
}