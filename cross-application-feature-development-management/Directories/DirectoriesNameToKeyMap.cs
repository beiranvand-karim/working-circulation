using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Directories
{
    public class DirectoriesNameToKeyMap(ICommandLineArgs commandLineArgs) : IDirectoriesNameToKeyMap
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetValue(string key)
        {
            const string groupKey = "DirectoriesNameToKeyMap";
            return commandLineArgs.GetKey2(groupKey, key);
        }
    }
}