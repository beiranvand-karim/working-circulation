namespace cafdemwimu.console.Names

open cafdemwimu.console

type PrimaryApplication() =
    member _.GetName() =
        let primaryApplicationNameKey = "--primary-application-name"
        let name = CommandLineArgs.GetByKey(primaryApplicationNameKey)
        name
