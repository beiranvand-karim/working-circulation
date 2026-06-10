namespace cafdemwimu.console

open System

type CommandLineArgs() =
    static member GetByKey(commandLineArgKey: string) =
        let commandLineArgs = Environment.GetCommandLineArgs()

        let index = Array.FindIndex(commandLineArgs, fun x -> x.StartsWith(commandLineArgKey))
        if index = -1 then
            $"couldn't find environment variable \"{commandLineArgKey}\" ..."
        else
            commandLineArgs.[index + 1]
