namespace cafdemwimu.console.Applications.DirectoryManagement.DirectoryOpenStrategies

type IDirectoryOpenStrategy =
    abstract member CanHandle: unit -> bool
    abstract member Open: path: string -> unit
