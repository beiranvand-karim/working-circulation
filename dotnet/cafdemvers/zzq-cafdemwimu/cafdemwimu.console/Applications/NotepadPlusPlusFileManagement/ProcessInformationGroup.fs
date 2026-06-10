namespace cafdemwimu.console.Applications.NotepadPlusPlusFileManagement

open System.Collections.Generic

[<AllowNullLiteral>]
type ProcessInformationGroup() =
    member val Group: List<ProcessInformation> = List<ProcessInformation>() with get, set

    member this.Add(processInformation: ProcessInformation) =
        this.Group.Add(processInformation)

    member this.AddInFront(processInformation: ProcessInformation) =
        this.Group.Insert(0, processInformation)
