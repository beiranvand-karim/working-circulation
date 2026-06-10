namespace cafdemwimu.console.Applications.NotepadPlusPlusFileManagement

open cafdemwimu.console

type NotepadPlusPlusFileManagementCommandSwitcher
    (
        processManager: ProcessManager,
        closeProcessManagement: CloseProcessManagement
    ) =
    member private _.GetCommand() =
        let command = CommandLineArgs.GetByKey("--command")
        command

    member private this.IsOpen() = this.GetCommand() = "open"

    member private this.IsClose() = this.GetCommand() = "close"

    member this.Run() =
        if this.IsOpen() then
            processManager.Run()
        elif this.IsClose() then
            closeProcessManagement.Run()
