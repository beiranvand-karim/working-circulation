namespace cafdemwimu.console.Applications.Cafdemalihapa

open System.IO
open cafdemwimu.console
open cafdemwimu.console.Helpers

type CodeBase(stringHelpers: StringHelpers) =
    member _.GetCodeBaseValue() =
        let codeBase = CommandLineArgs.GetByKey("--code-base")
        codeBase

    member _.GetContainingDirectory(cafdemExecutiveFileAddress: string) : string =
        let striped: string = stringHelpers.StripQuotationMarks(cafdemExecutiveFileAddress)
        let dirName: string = Path.GetDirectoryName(striped: string)
        dirName
