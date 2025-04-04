namespace cross_application_feature_development_management.Directories.Scripts.EnvironmentVariablesTemplatesDirectory
{
    public class EnvironmentVariablesTemplatesDirectory(
        CommandLineArgs commandLineArgs,
        AloneDirectory.AloneDirectory aloneDirectory,
        ScriptsDirectory scriptsDirectory
    )
    {
        public string GetPath()
        {
            var templateSourceDirectory_construction =
                Path.Combine(
                    scriptsDirectory.GetPath(),
                    GetName()
                );

            var templateSourceDirectory = aloneDirectory.IsAlone()
                ? aloneDirectory.GetName()
                : templateSourceDirectory_construction;

            return templateSourceDirectory;
        }

        private string GetName()
        {
            var templatesDirectoryNameKey =
                commandLineArgs.GetKey("TemplatesDirectoryNameKey");

            var templatesDirectoryName = CommandLineArgs.GetByKey(templatesDirectoryNameKey);
            return templatesDirectoryName;
        }
    }
}