using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management
{
    public class CommandSwitcher(
        ICommandLineArgs commandLineArgs,
        ICrossApplicationFeatureDevelopmentManagement crossApplicationFeatureDevelopmentManagement
        ) : ICommandSwitcher
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly ICrossApplicationFeatureDevelopmentManagement crossApplicationFeatureDevelopmentManagement = crossApplicationFeatureDevelopmentManagement;

        public string GetCommand()
        {
            string command = commandLineArgs.GetByKey("--command");
            return command;
        }

        private Boolean IsCreateScriptsCommand()
        {
            return GetCommand() == "create-scripts";
        }

        public void Run()
        {
            if (IsCreateScriptsCommand())
            {
                crossApplicationFeatureDevelopmentManagement.Run();
            }
        }
    }

    public interface ICommandSwitcher
    {
        public string GetCommand();
        public void Run();
    }
}