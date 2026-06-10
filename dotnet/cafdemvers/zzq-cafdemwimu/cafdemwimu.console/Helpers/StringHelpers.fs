namespace cafdemwimu.console.Helpers

type StringHelpers() =
    member _.WrapInQuotationMarks(value: string) =
        let valueToWrite = $"\"{value}\""
        valueToWrite

    member _.StripQuotationMarks(value: string) =
        let valueToWrite = value.Replace("\"", "")
        valueToWrite
