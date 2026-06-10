namespace cafdemwimu.console.Applications.NotepadPlusPlusFileManagement

open System.Diagnostics
open System.IO
open System.Threading
open System.Text.Json
open Microsoft.Extensions.Logging
open cafdemwimu.console
open cafdemwimu.console.Files.Executables
open cafdemwimu.console.Directories.Hosting.Feature.Automations.ProcessesMetaData
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndPrimary
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndSecondary
open cafdemwimu.console.Directories.Hosting.Feature.NotesAndMessages

type ProcessManager
    (
        notePadPlusPlus: NotepadPlusPlus,
        logger: ILogger<ProcessManager>,
        frontEndPrimaryDirectory: FrontEndPrimaryDirectory,
        frontEndSecondaryDirectory: FrontEndSecondaryDirectory,
        notesAndMessagesDirectory: NotesAndMessagesDirectory,
        processesMetaDataDirectory: ProcessesMetaDataDirectory
    ) =

    member private _.StartProcess(openeeFilesContainingDirectoryLocation: string, processInformationGroup: ProcessInformationGroup) =
        try
            let executiveFileLocation = notePadPlusPlus.GetPath()

            use myProcess = new Process()
            myProcess.StartInfo.UseShellExecute <- false
            myProcess.StartInfo.FileName <- executiveFileLocation
            myProcess.StartInfo.CreateNoWindow <- true
            myProcess.StartInfo.ArgumentList.Add("-multiInst")
            myProcess.StartInfo.ArgumentList.Add("-nosession")
            for file in Directory.EnumerateFiles(openeeFilesContainingDirectoryLocation) do
                myProcess.StartInfo.ArgumentList.Add(file)
            myProcess.Start() |> ignore
            logger.LogInformation("Process id: {Id}", myProcess.Id)
            let directoryInfo = DirectoryInfo(openeeFilesContainingDirectoryLocation)
            let dirName = directoryInfo.Name
            let processInformation = { GroupName = dirName; Id = System.Nullable(myProcess.Id) }
            processInformationGroup.AddInFront(processInformation)
        with e ->
            logger.LogInformation("{Message}", e.Message)

    member this.Run() =
        try
            let a = frontEndPrimaryDirectory.GetPath()
            let b = frontEndSecondaryDirectory.GetPath()
            let c = notesAndMessagesDirectory.GetPath()
            let processInformationGroup = ProcessInformationGroup()

            let orderValue = CommandLineArgs.GetByKey("--order")

            if orderValue = "reverse" then
                this.StartProcess(b, processInformationGroup)
                Thread.Sleep(100)
                this.StartProcess(a, processInformationGroup)
                Thread.Sleep(100)
                this.StartProcess(c, processInformationGroup)
            else
                this.StartProcess(a, processInformationGroup)
                Thread.Sleep(100)
                this.StartProcess(b, processInformationGroup)
                Thread.Sleep(100)
                this.StartProcess(c, processInformationGroup)

            logger.LogInformation("Process information group: {processInformationGroup}", JsonSerializer.Serialize(processInformationGroup))

            let dddd = JsonSerializer.Serialize(processInformationGroup)
            logger.LogInformation("Process information group: {processInformationGroup}", dddd)
            let x = processesMetaDataDirectory.GetPath()

            if not (Directory.Exists(x)) then
                Directory.CreateDirectory(x) |> ignore

            let notepadPlusPlusFileProcessesMetaDataDirectory = Path.Combine(x, "notepad-plus-plus-file-processes-meta-data.json")
            File.WriteAllText(notepadPlusPlusFileProcessesMetaDataDirectory, dddd)
        with e ->
            logger.LogInformation("ProcessManager: {Message}", e.Message)

    member _.LoadJson() =
        let notepadPlusPlusFileProcessesMetaDataDirectory = Path.Combine(processesMetaDataDirectory.GetPath(), "notepad-plus-plus-file-processes-meta-data.json")
        let json =
            use r = new StreamReader(notepadPlusPlusFileProcessesMetaDataDirectory)
            r.ReadToEnd()
        let _items = Newtonsoft.Json.JsonConvert.DeserializeObject<ProcessInformationGroup>(json)
        ()
