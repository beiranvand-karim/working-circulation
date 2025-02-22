using cross_application_feature_development_management.Interfaces;
using cross_application_feature_development_management.Names.Interfaces;

namespace cross_application_feature_development_management.Names.Classses
{
    public class HostApplicationName(ICommandLineArgs commandLineArgs) : IHostApplicationName
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetName()
        {
            const string hostApplicationNameKey = "--host-application-name";
            var name = commandLineArgs.GetByKey(hostApplicationNameKey);
            return name;
        }
    }
}