using cross_application_feature_development_management.Applications.IdeManagement;

namespace cross_application_feature_development_management
{
    public class CrossApplicationFeatureDevelopmentManagementCommandSwitcher(
        CommandLineArgs commandLineArgs,
        CrossApplicationFeatureDevelopmentManagement crossApplicationFeatureDevelopmentManagement,
        NotepadPlusPlusFileManagementCommandSwitcher notepadPlusPlusFileManagementCommandSwitcher,
        IdeManagement ideManagement 
        )
    {
        private string GetApplication()
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
}