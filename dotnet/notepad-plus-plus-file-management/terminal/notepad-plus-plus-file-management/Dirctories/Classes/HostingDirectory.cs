using notepad_plus_plus_file_management.Dirctories.Interfaces;
using notepad_plus_plus_file_management.Interfaces;

namespace notepad_plus_plus_file_management.Dirctories.Classes
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