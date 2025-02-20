using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Applications.IdeManagement
{
    public class IdeManagement(
        ICommandLineArgs commandLineArgs,
        IProcessManager processManager,
        ICloseProcessManagement closeProcessManagement,
        IdeProcessManagement ideProcessManagement
    ):IApplication
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly IProcessManager processManager = processManager;
        private readonly ICloseProcessManagement closeProcessManagement = closeProcessManagement;
        private readonly IdeProcessManagement ideProcessManagement = ideProcessManagement;

        public string GetCommand()
        {
            var command = commandLineArgs.GetByKey("--command");
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
                ideProcessManagement.Open();
            }
            else if (IsClose())
            {
                ideProcessManagement.Close();
            }
        }
    }

    public interface IIdeManagement
    {
        public void Run();
    }
}