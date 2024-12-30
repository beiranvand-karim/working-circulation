using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management
{
    public class CrossApplicationFeatureDevelopmentManagementCommandSwitcher(
        ICommandLineArgs commandLineArgs,
        ICrossApplicationFeatureDevelopmentManagement crossApplicationFeatureDevelopmentManagement
        ) : ICrossApplicationFeatureDevelopmentManagementCommandSwitcher
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

        private Boolean IsNotepadPlusPlusFileManagementCommand()
        {
            return GetCommand() == "cross-application-feature-development-management";
        }

        public void Run()
        {
            if (IsCreateScriptsCommand())
            {
                crossApplicationFeatureDevelopmentManagement.Run();
            }

            if (IsNotepadPlusPlusFileManagementCommand())
            {
                crossApplicationFeatureDevelopmentManagement.Run();
            }
        }

    }

    public interface ICrossApplicationFeatureDevelopmentManagementCommandSwitcher
    {
        public string GetCommand();
        public void Run();
    }
}