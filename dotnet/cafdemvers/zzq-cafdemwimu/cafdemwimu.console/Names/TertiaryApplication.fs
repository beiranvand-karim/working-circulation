namespace cafdemwimu.console.Names

open cafdemwimu.console

type TertiaryApplication() =
    member _.GetName() =
        let tertiaryApplicationNameKey = "--tertiary-application-name"
        let name = CommandLineArgs.GetByKey(tertiaryApplicationNameKey)
        name
