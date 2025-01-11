using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Classes
{
    public class ScriptsDirectory(ICommandLineArgs commandLineArgs) : IScriptsDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetName()
        {
            var scriptsDirectoryNameKey = commandLineArgs.GetKey("ScriptsDirectoryNameKey");
            var scriptsDirectoryName = commandLineArgs.GetByKey(scriptsDirectoryNameKey);
            return scriptsDirectoryName;
        }
    }
}