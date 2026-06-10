namespace cafdemwimu.console.Applications

open System.Runtime.CompilerServices
open cafdemwimu.console

[<Extension>]
type Applications =
    static member Get() =
        let application = CommandLineArgs.GetByKey("--application")
        application

    [<Extension>]
    static member IsCafdemalihapa(application: string) = application = "cafdemalihapa"

    [<Extension>]
    static member IsNotepadPlusPlusFileManagementApplication(application: string) = application = "notepad-plus-plus-file-management"

    [<Extension>]
    static member IsIdeManagementApplication(application: string) = application = "ide-management"

    [<Extension>]
    static member IsDirectoryManagementApplication(application: string) = application = "directory-management"
