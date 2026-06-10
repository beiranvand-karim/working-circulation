namespace cafdemwimu.console.Directories

open System.IO

[<AbstractClass; Sealed>]
type DirectoryServices private () =
    static member ReplaceFileNameWithPath(receiverPath: string, giverPath: string) =
        let fileName = Path.GetFileName(giverPath)
        let text = File.ReadAllText(receiverPath)
        if isNull text then nullArg "receiverPath"
        let text = text.Replace(fileName, giverPath)
        File.WriteAllText(receiverPath, text)

    static member ReplaceFileNameWithPath(receiverPath: string, replacee: string, replacer: string) =
        let text = File.ReadAllText(receiverPath)
        if isNull text then nullArg "receiverPath"
        let text = text.Replace(replacee, replacer)
        File.WriteAllText(receiverPath, text)

    static member CopyFileToDestinationDirectory(file: string, destinationDirectory: string) =
        let fileName = Path.GetFileName(file)
        let destFileName = Path.GetFileName(fileName)
        let destFilePathIncludingName = Path.Combine(destinationDirectory, destFileName)
        File.Copy(file, destFilePathIncludingName)

    static member CopyContentOfSourceDirectoryToDestinationDirectory(sourceDirectory: string, destinationDirectory: string) =
        for file in Directory.EnumerateFiles(sourceDirectory) do
            DirectoryServices.CopyFileToDestinationDirectory(file, destinationDirectory)
