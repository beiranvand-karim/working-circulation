namespace cross_application_feature_development_management
{
    public class NotepadPlusPlusFileManagementCommandSwitcher(
        ProcessManager processManager,
        CloseProcessManagement closeProcessManagement
        )
    {
        private string GetCommand()
        {
            var command = CommandLineArgs.GetByKey("--command");
            return command;
        }

        private bool IsOpen()
        {
            return GetCommand() == "open";
        }

        private bool IsClose()
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
}