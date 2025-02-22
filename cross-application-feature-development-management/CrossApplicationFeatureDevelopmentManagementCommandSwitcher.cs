using cross_application_feature_development_management.Applications.IdeManagement;
using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management
{
    public class CrossApplicationFeatureDevelopmentManagementCommandSwitcher(
        ICommandLineArgs commandLineArgs,
        ICrossApplicationFeatureDevelopmentManagement crossApplicationFeatureDevelopmentManagement,
        INotepadPlusPlusFileManagementCommandSwitcher notepadPlusPlusFileManagementCommandSwitcher,
        IIdeManagement  ideManagement 
        ) : ICrossApplicationFeatureDevelopmentManagementCommandSwitcher
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly ICrossApplicationFeatureDevelopmentManagement crossApplicationFeatureDevelopmentManagement = crossApplicationFeatureDevelopmentManagement;
        private readonly INotepadPlusPlusFileManagementCommandSwitcher notepadPlusPlusFileManagementCommandSwitcher = notepadPlusPlusFileManagementCommandSwitcher;
        private readonly IIdeManagement ideManagement = ideManagement;

        public string GetApplication()
        {
            var application = commandLineArgs.GetByKey("--application");
            return application;
        }

        private bool IsCrossApplicationFeatureDevelopmentManagementApplication()
        {
            return GetApplication() == "cross-application-feature-development-management";
        }

        private bool IsNotepadPlusPlusFileManagementApplication()
        {
            return GetApplication() == "notepad-plus-plus-file-management";
        }

        private bool IsIdeManagementApplication()
        {
            return GetApplication() == "ide-management";
        }

        public void Run()
        {
            if (IsCrossApplicationFeatureDevelopmentManagementApplication())
            {
                crossApplicationFeatureDevelopmentManagement.Run();
            }

            if (IsNotepadPlusPlusFileManagementApplication())
            {
                notepadPlusPlusFileManagementCommandSwitcher.Run();
            }

            if(IsIdeManagementApplication())
            {
                ideManagement.Run();
            }
        }

    }

    public interface ICrossApplicationFeatureDevelopmentManagementCommandSwitcher
    {
        public string GetApplication();
        public void Run();
    }
}