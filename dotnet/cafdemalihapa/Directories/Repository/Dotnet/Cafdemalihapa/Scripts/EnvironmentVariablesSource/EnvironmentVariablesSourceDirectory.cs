namespace cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource
{
    public class EnvironmentVariablesSourceDirectory(
        ScriptsDirectory scriptsDirectory
        )
    {
        public string GetPath()
        {
            var environmentVariablesSourceDirectory =
                Path.Combine(scriptsDirectory.GetPath(), "environment-variables-source");

            return environmentVariablesSourceDirectory;
        }
    }
}