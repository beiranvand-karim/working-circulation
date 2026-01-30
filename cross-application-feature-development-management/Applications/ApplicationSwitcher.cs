using cross_application_feature_development_management.Applications.Cafdem;
using cross_application_feature_development_management.Applications.NotepadPlusPlusFileManagement;

namespace cross_application_feature_development_management.Applications
{
    public class ApplicationSwitcher(
        CrossApplicationFeatureDevelopmentManagement crossApplicationFeatureDevelopmentManagement,
        NotepadPlusPlusFileManagementCommandSwitcher notepadPlusPlusFileManagementCommandSwitcher,
        IdeManagement.IdeManagement ideManagement,
        DirectoryManagement.DirectoryManagement directoryManagement
        )
    {
        private string GetApplication()
        {
            var application = CommandLineArgs.GetByKey("--application");
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
            directoryManagement.Run();
        }
    }
}