namespace cafdemwimu.console.Applications.IdeManagement

open System.Collections.Generic

[<AllowNullLiteral>]
type IdeProcessInformationGroup() =
    member val Group: List<IdeProcessInformation> = List<IdeProcessInformation>() with get, set

    member this.Add(ideProcessInformation: IdeProcessInformation) =
        this.Group.Add(ideProcessInformation)

    member this.AddInFront(ideProcessInformation: IdeProcessInformation) =
        this.Group.Insert(0, ideProcessInformation)
