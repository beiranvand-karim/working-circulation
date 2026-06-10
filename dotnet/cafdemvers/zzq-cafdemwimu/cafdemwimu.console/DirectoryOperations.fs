namespace cafdemwimu.console

open System.IO
open Microsoft.Extensions.Logging

type DirectoryOperations(logger: ILogger<DirectoryOperations>) =
    member _.ListFilesToConsole(sourceDirectory: string) =
        for file in Directory.EnumerateFiles(sourceDirectory) do
            logger.LogInformation("{file}", file)
