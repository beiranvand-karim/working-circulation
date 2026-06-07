using CafdemalihapaApp = cafdemalihapa.Applications.Cafdemalihapa.Cafdemalihapa;
using cafdemalihapa.Applications.NotepadPlusPlusFileManagement;

namespace cafdemalihapa.Applications
{
    public class ApplicationSwitcher(
        CafdemalihapaApp cafdemalihapa,
        NotepadPlusPlusFileManagementCommandSwitcher notepadPlusPlusFileManagementCommandSwitcher,
        IdeManagement.IdeManagement ideManagement,
        DirectoryManagement.DirectoryManagement directoryManagement
        )
    {
        public void Run()
        {
            if (Applications.Get().IsCafdemalihapa())
            {
                cafdemalihapa.Run();
            }

            if (Applications.Get().IsNotepadPlusPlusFileManagementApplication())
            {
                notepadPlusPlusFileManagementCommandSwitcher.Run();
            }

            if (Applications.Get().IsIdeManagementApplication())
            {
                ideManagement.Run();
            }
            directoryManagement.Run();
        }
    }
}