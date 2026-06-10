namespace cafdemwimu.console.Names

open cafdemwimu.console

type IdeName() =
    member _.GetName() =
        let ideNameKey = "--ide-name"
        let name = CommandLineArgs.GetByKey(ideNameKey)
        name
