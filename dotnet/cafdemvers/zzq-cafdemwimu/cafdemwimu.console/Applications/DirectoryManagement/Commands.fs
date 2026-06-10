namespace cafdemwimu.console.Applications

open System.Runtime.CompilerServices
open cafdemwimu.console

[<Extension>]
type Commands =
    static member Get() =
        let command = CommandLineArgs.GetByKey("--command")
        command

    [<Extension>]
    static member IsCreate(command: string) = command = "create"

    [<Extension>]
    static member IsOpen(command: string) = command = "open"

    [<Extension>]
    static member IsShut(command: string) = command = "shut"

    [<Extension>]
    static member IsDirectoryToBeOpen(command: string) = command = "directory-to-be-open"
