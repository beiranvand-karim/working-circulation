namespace cafdemwimu.console.Applications.Cafdemalihapa

open cafdemwimu.console

type CodeBase() =
    member _.GetCodeBaseValue() =
        let codeBase = CommandLineArgs.GetByKey("--code-base")
        codeBase
