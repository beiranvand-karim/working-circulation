using notepad_plus_plus_file_management.Interfaces;

namespace notepad_plus_plus_file_management
{
    public class CommandSwitcher(
        ICommandLineArgs commandLineArgs,
        IProcessManager processManager,
        ICloseProcessManagement closeProcessManagement
        ) : ICommandSwitcher
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IProcessManager processManager = processManager;
        private readonly ICloseProcessManagement closeProcessManagement = closeProcessManagement;

        public string GetCommand()
        {
            string command = commandLineArgs.GetByKey("--command");
            return command;
        }

        private Boolean isOpen()
        {
            return GetCommand() == "open";
        }

        private Boolean isClose()
        {
            return GetCommand() == "close";
        }

        public void Run()
        {
            if (isOpen())
            {
                processManager.Run();
            }
            else if (isClose())
            {
                closeProcessManagement.Run();
            }
        }
    }

    public interface ICommandSwitcher
    {
        public string GetCommand();
        public void Run();
    }
}