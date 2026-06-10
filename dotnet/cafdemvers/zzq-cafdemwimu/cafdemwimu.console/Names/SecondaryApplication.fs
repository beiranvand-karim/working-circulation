namespace cafdemwimu.console.Names

open cafdemwimu.console

type SecondaryApplication() =
    member _.GetName() =
        let secondaryApplicationNameKey = "--secondary-application-name"
        let name = CommandLineArgs.GetByKey(secondaryApplicationNameKey)
        name
