namespace cafdemwimu.console.Applications.IdeManagement

open cafdemwimu.console

type IdeManagement(ideProcessManagement: IdeProcessManagement) =
    member private _.GetCommand() =
        let command = CommandLineArgs.GetByKey("--command")
        command

    member private this.IsOpen() = this.GetCommand() = "open"

    member private this.IsClose() = this.GetCommand() = "close"

    member this.Run() =
        if this.IsOpen() then
            ideProcessManagement.Open()
        elif this.IsClose() then
            ideProcessManagement.Close()
