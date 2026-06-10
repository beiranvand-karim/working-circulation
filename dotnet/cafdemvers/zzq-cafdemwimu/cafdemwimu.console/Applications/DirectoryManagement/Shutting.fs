namespace cafdemwimu.console.Applications.DirectoryManagement

open cafdemwimu.console.Applications

type Shutting() =
    member _.Shut() =
        if not (Commands.Get().IsShut()) then
            ()
