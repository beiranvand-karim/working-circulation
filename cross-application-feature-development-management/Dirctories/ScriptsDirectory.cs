
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Dirctories
{
    public class ScriptsDirectory(ICommandLineArgs commandLineArgs): IScriptsDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetName()
        {
            string scriptsDirectoryNameKey = commandLineArgs.GetKey("ScriptsDirectoryNameKey");
            string scriptsDirectoryName = commandLineArgs.GetByKey(scriptsDirectoryNameKey);
            return scriptsDirectoryName;
        }
    }
}