using System.Diagnostics;
using System.Text.Json;
using cross_application_feature_development_management.Directories.Applications;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;
using cross_application_feature_development_management.Files.Executables;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Applications.IdeManagement
{
    public class IdeProcessManagement(
        IIdeExecutiveFileLocation ideExecutiveFileLocation,
        ILogger<IdeProcessManagement> logger,
        IProcessesMetaDataDirectory processesMetaDataDirectory,
        IApplicationLocation  applicationLocation
    ): IIdeProcessManagement
    {
        private readonly IIdeExecutiveFileLocation ideExecutiveFileLocation = ideExecutiveFileLocation;
        private readonly IProcessesMetaDataDirectory processesMetaDataDirectory = processesMetaDataDirectory;
        private readonly IApplicationLocation applicationLocation = applicationLocation;

        public void Open()
        {
                ProcessInformationGroup processInformationGroup = new();

                this.StartProcess(processInformationGroup);

                logger.LogInformation("Process information group: {processInformationGroup}", JsonSerializer.Serialize(processInformationGroup));

                var processInformationGroup_Serialized = JsonSerializer.Serialize(processInformationGroup);
                logger.LogInformation("Process information group: {processInformationGroup}", processInformationGroup_Serialized);
                var processesMetaDataDirectory_path = processesMetaDataDirectory.GetPath();

                if (!Directory.Exists(processesMetaDataDirectory_path))
                {
                    Directory.CreateDirectory(processesMetaDataDirectory_path);
                }

                var ideManagementProcessesMetaDataFile = Path.Combine(processesMetaDataDirectory_path, "ide-management-processes-meta-data.json");
                File.WriteAllText(ideManagementProcessesMetaDataFile, processInformationGroup_Serialized);
        }

        public void Close()
        {
            var ideManagementProcessesMetaDataFile = Path.Combine(processesMetaDataDirectory.GetPath(), "ide-management-processes-meta-data.json");

            using StreamReader r = new(ideManagementProcessesMetaDataFile);
            var json = r.ReadToEnd();
            var readProcessInformationGroup = Newtonsoft.Json.JsonConvert.DeserializeObject<ProcessInformationGroup>(json);

            logger.LogInformation("items, {items}", readProcessInformationGroup);

            foreach (var pInfo in readProcessInformationGroup?.group)
            {
                logger.LogInformation("Id: {Id}", pInfo?.id);
                var p = Process.GetProcessById((int)pInfo?.id);
                p.Kill();
                Thread.Sleep(2000);
            }
        }


        private void StartProcess(ProcessInformationGroup processInformationGroup)
        {
            try
            {
                var executiveFileLocation = ideExecutiveFileLocation.GetPath();
                var applicationLocation_path = applicationLocation.GetPath();

                using Process myProcess = new();
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = executiveFileLocation;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.ArgumentList.Add(applicationLocation_path);

                myProcess.Start();
                logger.LogInformation("Process id: {Id}", myProcess.Id);
                ProcessInformation processInformation = new() { groupName = "ide", id = myProcess.Id };
                processInformationGroup.AddInFront(processInformation);
            }
            catch (Exception e)
            {
                logger.LogInformation("{Message}", e.Message);
            }
        }
    }

    public interface IIdeProcessManagement
    {
        public void Open();
        public void Close();

    }
}