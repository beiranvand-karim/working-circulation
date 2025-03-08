namespace cross_application_feature_development_management.Directories
{
    public class TemplatesDirectory(
        CommandLineArgs commandLineArgs,
        AloneDirectory aloneDirectory,
        ScriptsDirectory scriptsDirectory
    )
    {
        public string GetPath()
        {
            var templateSourceDirectory_construction =
                Path.Combine(
                    scriptsDirectory.GetName(),
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