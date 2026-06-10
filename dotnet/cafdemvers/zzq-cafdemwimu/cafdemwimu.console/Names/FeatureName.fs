namespace cafdemwimu.console.Names

open cafdemwimu.console

type FeatureName() =
    member _.GetName() =
        let featureNameKey = "--feature-name"
        let name = CommandLineArgs.GetByKey(featureNameKey)
        name
