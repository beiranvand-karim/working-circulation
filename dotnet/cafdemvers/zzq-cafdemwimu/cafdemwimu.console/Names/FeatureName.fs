namespace cafdemwimu.console.Names

open cafdemwimu.console
open cafdemwimu.console.Helpers

type FeatureName() =
    member _.GetName() =
        let featureNameKey = "--feature-name"
        let name = CommandLineArgs.GetByKey(featureNameKey)
        name

    member this.GetWrappedName(stringHelpers: StringHelpers) : string =
        let featureNameValue = this.GetName()
        let wrappedFeatureName = stringHelpers.WrapInQuotationMarks(featureNameValue)
        wrappedFeatureName
