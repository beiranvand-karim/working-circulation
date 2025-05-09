using notepad_plus_plus_file_management.Interfaces;

namespace notepad_plus_plus_file_management
{
    public class NotepadPlusPlusFileManagementCommandSwitcher(
        ICommandLineArgs commandLineArgs,
        IProcessManager processManager,
        ICloseProcessManagement closeProcessManagement
        ) : INotepadPlusPlusFileManagementCommandSwitcher
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IProcessManager processManager = processManager;
        private readonly ICloseProcessManagement closeProcessManagement = closeProcessManagement;

        public string GetCommand()
        {
            string command = commandLineArgs.GetByKey("--command");
            return command;
        }

        private Boolean IsOpen()
        {
            return GetCommand() == "open";
        }

        private Boolean IsClose()
        {
            return GetCommand() == "close";
        }

        public void Run()
        {
            if (IsOpen())
            {
                processManager.Run();
            }
            else if (IsClose())
            {
                closeProcessManagement.Run();
            }
        }
    }

    public interface INotepadPlusPlusFileManagementCommandSwitcher
    {
        public string GetCommand();
        public void Run();
    }
}