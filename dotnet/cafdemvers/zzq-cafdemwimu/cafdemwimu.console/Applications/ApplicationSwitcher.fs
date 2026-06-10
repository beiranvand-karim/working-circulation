namespace cafdemwimu.console.Applications

open cafdemwimu.console.Applications.NotepadPlusPlusFileManagement

type CafdemalihapaApp = cafdemwimu.console.Applications.Cafdemalihapa.Cafdemalihapa

type ApplicationSwitcher
    (
        cafdemalihapa: CafdemalihapaApp,
        notepadPlusPlusFileManagementCommandSwitcher: NotepadPlusPlusFileManagementCommandSwitcher,
        ideManagement: cafdemwimu.console.Applications.IdeManagement.IdeManagement,
        directoryManagement: cafdemwimu.console.Applications.DirectoryManagement.DirectoryManagement
    ) =
    member _.Run() =
        if Applications.Get().IsCafdemalihapa() then
            cafdemalihapa.Run()

        if Applications.Get().IsNotepadPlusPlusFileManagementApplication() then
            notepadPlusPlusFileManagementCommandSwitcher.Run()

        if Applications.Get().IsIdeManagementApplication() then
            ideManagement.Run()

        directoryManagement.Run()
