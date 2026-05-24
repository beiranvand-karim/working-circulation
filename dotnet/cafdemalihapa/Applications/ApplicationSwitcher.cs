using cafdemalihapa.Applications.Cafdem;
using cafdemalihapa.Applications.NotepadPlusPlusFileManagement;

namespace cafdemalihapa.Applications
{
    public class ApplicationSwitcher(
        Cafdemalihapa cafdemalihapa,
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

        private bool IsCafdemalihapa()
        {
            return GetApplication() == "cafdemalihapa";
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
            if (IsCafdemalihapa())
            {
                cafdemalihapa.Run();
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