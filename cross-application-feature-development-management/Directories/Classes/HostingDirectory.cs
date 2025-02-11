using cross_application_feature_development_management.Directories.Interfaces;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Directories.Classes
{
    public class HostingDirectory(ICommandLineArgs commandLineArgs) : IHostingDirectory
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetName()
        {
            var hostingDirectoryNameKey = commandLineArgs.GetKey("HostingDirectoryNameKey");
            var hostingDirectoryName = commandLineArgs.GetByKey(hostingDirectoryNameKey);
            return hostingDirectoryName;
        }
    }
}