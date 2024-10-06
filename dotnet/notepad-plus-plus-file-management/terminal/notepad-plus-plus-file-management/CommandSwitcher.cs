using notepad_plus_plus_file_management.Interfaces;

namespace notepad_plus_plus_file_management
{
    public class CommandSwitcher(
        ICommandLineArgs commandLineArgs,
        IProcessManager processManager
        ) : ICommandSwitcher
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IProcessManager processManager = processManager;

        public string GetCommand()
        {
            string command = commandLineArgs.GetByKey("--command");
            return command;
        }

        public void Run()
        {
            if (GetCommand() == "open")
            {
                processManager.Run();
            }
        }
    }

    public interface ICommandSwitcher
    {
        public string GetCommand();
        public void Run();
    }
}