namespace cafdemwimu.console.Applications.IdeManagement

open System

[<CLIMutable>]
type IdeProcessInformation =
    { GroupName: string
      Id: Nullable<int>
      IdeName: string
      ApplicationName: string }
