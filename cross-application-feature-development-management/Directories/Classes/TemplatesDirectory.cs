using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Directories.Classes
{
    public class TemplatesDirectory(
        ICommandLineArgs commandLineArgs,
        AloneDirectory aloneDirectory,
        ScriptsDirectory scriptsDirectory
    ) : ITemplatesDirectory
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

        public string GetName()
        {
            var templatesDirectoryNameKey =
                commandLineArgs.GetKey("TemplatesDirectoryNameKey");

            var templatesDirectoryName = commandLineArgs.GetByKey(templatesDirectoryNameKey);
            return templatesDirectoryName;
        }
    }
}