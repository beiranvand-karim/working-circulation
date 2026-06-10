namespace cafdemwimu.console.Names

open cafdemwimu.console

type ApplicationName() =
    member _.GetName() =
        let applicationNameKey = "--application-name"
        let name = CommandLineArgs.GetByKey(applicationNameKey)
        name
