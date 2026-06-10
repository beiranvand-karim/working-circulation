namespace cafdemwimu.console.Directories

module internal NullHelpers =
    let orEmpty (s: string) = if isNull s then "" else s
