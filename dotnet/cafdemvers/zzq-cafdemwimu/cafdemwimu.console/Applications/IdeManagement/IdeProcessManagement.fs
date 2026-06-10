namespace cafdemwimu.console.Applications.IdeManagement

open System.Diagnostics
open System.IO
open System.Linq
open System.Text.Json
open Microsoft.Extensions.Logging
open cafdemwimu.console.Names
open cafdemwimu.console.Files.Executables
open cafdemwimu.console.Directories.Applications
open cafdemwimu.console.Directories.Hosting.Feature.Automations.ProcessesMetaData

type IdeProcessManagement
    (
        ideExecutiveFileLocation: IdeExecutiveFileLocation,
        logger: ILogger<IdeProcessManagement>,
        processesMetaDataDirectory: ProcessesMetaDataDirectory,
        applicationLocation: ApplicationLocation,
        ideName: IdeName,
        applicationName: ApplicationName
    ) =

    member private _.StartProcess() : IdeProcessInformation =
        let executiveFileLocation = ideExecutiveFileLocation.GetPath()
        let applicationLocation_path = applicationLocation.GetPath()

        use myProcess = new Process()
        myProcess.StartInfo.UseShellExecute <- false
        myProcess.StartInfo.FileName <- executiveFileLocation
        myProcess.StartInfo.CreateNoWindow <- true
        myProcess.StartInfo.ArgumentList.Add(applicationLocation_path)

        myProcess.Start() |> ignore
        logger.LogInformation("Process id: {Id}", myProcess.Id)

        { GroupName = "ide"
          Id = System.Nullable(myProcess.Id)
          IdeName = ideName.GetName()
          ApplicationName = applicationName.GetName() }

    member this.Open() =
        let ideProcessInformationGroup = IdeProcessInformationGroup()

        let pro = this.StartProcess()

        let processesMetaDataDirectory_path = processesMetaDataDirectory.GetPath()

        if not (Directory.Exists(processesMetaDataDirectory_path)) then
            Directory.CreateDirectory(processesMetaDataDirectory_path) |> ignore

        let ideManagementProcessesMetaDataFile = Path.Combine(processesMetaDataDirectory_path, "ide-management-processes-meta-data.json")

        if File.Exists(ideManagementProcessesMetaDataFile) then
            let json =
                use r = new StreamReader(ideManagementProcessesMetaDataFile)
                r.ReadToEnd()
            let ideProcessInformationGroup_json = Newtonsoft.Json.JsonConvert.DeserializeObject<IdeProcessInformationGroup>(json)
            if not (isNull ideProcessInformationGroup_json) then
                ideProcessInformationGroup_json.AddInFront(pro)
            let ideProcessInformationGroup_Serialized1 = JsonSerializer.Serialize(ideProcessInformationGroup_json)
            File.WriteAllText(ideManagementProcessesMetaDataFile, ideProcessInformationGroup_Serialized1)
        else
            ideProcessInformationGroup.Add(pro)
            let ideProcessInformationGroup_Serialized1 = JsonSerializer.Serialize(ideProcessInformationGroup)
            File.WriteAllText(ideManagementProcessesMetaDataFile, ideProcessInformationGroup_Serialized1)

    member _.Close() =
        let ideManagementProcessesMetaDataFile = Path.Combine(processesMetaDataDirectory.GetPath(), "ide-management-processes-meta-data.json")

        if File.Exists(ideManagementProcessesMetaDataFile) then
            let json =
                use r = new StreamReader(ideManagementProcessesMetaDataFile)
                r.ReadToEnd()
            let ideProcessInformationGroup_json = Newtonsoft.Json.JsonConvert.DeserializeObject<IdeProcessInformationGroup>(json)

            if not (isNull ideProcessInformationGroup_json) then
                let matches (p: IdeProcessInformation) =
                    p.IdeName = ideName.GetName() && p.ApplicationName = applicationName.GetName()

                let ideProcessInformation_selected =
                    ideProcessInformationGroup_json.Group
                    |> Seq.filter matches
                    |> Seq.head

                logger.LogInformation("ApplicationName, {ApplicationName}", ideProcessInformation_selected.ApplicationName)
                logger.LogInformation("IdeName, {IdeName}", ideProcessInformation_selected.IdeName)
                logger.LogInformation("Id, {Id}", ideProcessInformation_selected.Id)

                let p = Process.GetProcessById(ideProcessInformation_selected.Id.GetValueOrDefault(0))
                p.Kill()

                let ideProcessInformation_selected_2 =
                    ideProcessInformationGroup_json.Group
                    |> Seq.filter matches
                    |> Seq.tryExactlyOne

                match ideProcessInformation_selected_2 with
                | Some s ->
                    ideProcessInformationGroup_json.Group.Remove(s) |> ignore
                    let ideProcessInformationGroup_Serialized1 = JsonSerializer.Serialize(ideProcessInformationGroup_json)
                    File.WriteAllText(ideManagementProcessesMetaDataFile, ideProcessInformationGroup_Serialized1)
                | None -> ()
