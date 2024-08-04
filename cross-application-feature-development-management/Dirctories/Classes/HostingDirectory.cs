using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Dirctories.Classes
{
    public class HostingDirectory(ICommandLineArgs commandLineArgs) : IHostingDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetName()
        {
            string hostingDirectoryNameKey = commandLineArgs.GetKey("HostingDirectoryNameKey");
            string hostingDirectoryName = commandLineArgs.GetByKey(hostingDirectoryNameKey);
            return hostingDirectoryName;
        }
    }
}