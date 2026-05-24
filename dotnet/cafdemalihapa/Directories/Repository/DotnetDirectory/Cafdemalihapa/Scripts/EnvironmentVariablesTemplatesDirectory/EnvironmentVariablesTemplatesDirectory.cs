namespace cafdemalihapa.Directories.Repository.DotnetDirectory.Cafdemalihapa.Scripts.EnvironmentVariablesTemplatesDirectory
{
    public class EnvironmentVariablesTemplatesDirectory(
        AloneDirectory.AloneDirectory aloneDirectory,
        ScriptsDirectory scriptsDirectory
    )
    {
        public string GetPath()
        {
            var templateSourceDirectory_construction =
                Path.Combine(
                    scriptsDirectory.GetPath(),
                    "environment-variables-template-files"
                );

            var templateSourceDirectory = aloneDirectory.IsAlone()
                ? aloneDirectory.GetName()
                : templateSourceDirectory_construction;

            return templateSourceDirectory;
        }
    }
}