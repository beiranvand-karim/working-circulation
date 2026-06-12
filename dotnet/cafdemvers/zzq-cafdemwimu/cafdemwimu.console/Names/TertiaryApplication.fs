namespace cafdemwimu.console.Names

open cafdemwimu.console
open cafdemwimu.console.Helpers

type TertiaryApplication() =
    member _.GetName() =
        let tertiaryApplicationNameKey = "--tertiary-application-name"
        let name = CommandLineArgs.GetByKey(tertiaryApplicationNameKey)
        name

    member this.GetWrappedName(stringHelpers: StringHelpers) : string =
        let tertiaryApplicationName = this.GetName()
        let wrappedTertiaryApplicationName = stringHelpers.WrapInQuotationMarks(tertiaryApplicationName)
        wrappedTertiaryApplicationName
