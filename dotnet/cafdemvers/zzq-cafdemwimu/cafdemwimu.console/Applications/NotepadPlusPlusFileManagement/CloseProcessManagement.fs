namespace cafdemwimu.console.Applications.NotepadPlusPlusFileManagement

open System.Diagnostics
open System.IO
open Microsoft.Extensions.Logging
open cafdemwimu.console.Directories.Hosting.Feature.Automations.ProcessesMetaData

type CloseProcessManagement
    (
        logger: ILogger<CloseProcessManagement>,
        processesMetaDataDirectory: ProcessesMetaDataDirectory
    ) =
    member _.Run() =
        let notepadPlusPlusFileProcessesMetaDataDirectory = Path.Combine(processesMetaDataDirectory.GetPath(), "notepad-plus-plus-file-processes-meta-data.json")

        let json =
            use r = new StreamReader(notepadPlusPlusFileProcessesMetaDataDirectory)
            r.ReadToEnd()
        let readProcessInformationGroup = Newtonsoft.Json.JsonConvert.DeserializeObject<ProcessInformationGroup>(json)

        logger.LogInformation("items, {items}", readProcessInformationGroup)

        if not (isNull readProcessInformationGroup) then
            for pInfo in readProcessInformationGroup.Group do
                logger.LogInformation("Id: {Id}", pInfo.Id)
                let p = Process.GetProcessById(pInfo.Id.GetValueOrDefault(0))
                p.Kill()
