using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Directories.Classes
{
    public class TemplatesDirectory(ICommandLineArgs commandLineArgs) : ITemplatesDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetName()
        {
            var templatesDirectoryNameKey =
                commandLineArgs.GetKey("TemplatesDirectoryNameKey");

            var templatesDirectoryName = commandLineArgs.GetByKey(templatesDirectoryNameKey);
            return templatesDirectoryName;
        }
    }
}