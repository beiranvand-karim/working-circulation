namespace cafdemwimu.console.Applications.DirectoryManagement.DirectoryOpenStrategies

open System.Diagnostics
open Microsoft.Extensions.Logging

[<AbstractClass>]
type DirectoryOpenStrategy(logger: ILogger) =
    abstract member FileName: string

    abstract member CanHandle: unit -> bool

    abstract member TransformPath: path: string -> string
    default _.TransformPath(path) = path

    member this.Open(path: string) =
        let argument = this.TransformPath(path)

        logger.LogInformation("path: {path}", path)
        logger.LogInformation("argument: {argument}", argument)

        use myProcess = new Process()
        myProcess.StartInfo.UseShellExecute <- false
        myProcess.StartInfo.FileName <- this.FileName
        myProcess.StartInfo.CreateNoWindow <- true
        myProcess.StartInfo.ArgumentList.Add(argument)

        myProcess.Start() |> ignore

        logger.LogInformation("myProcess: {myProcess}", myProcess.Id)

    interface IDirectoryOpenStrategy with
        member this.CanHandle() = this.CanHandle()
        member this.Open(path) = this.Open(path)
