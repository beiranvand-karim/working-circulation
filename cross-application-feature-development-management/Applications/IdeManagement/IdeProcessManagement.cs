using System.Diagnostics;
using System.Text.Json;
using cross_application_feature_development_management.Directories.Applications;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;
using cross_application_feature_development_management.Files.Executables;
using cross_application_feature_development_management.Names.Classses;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Applications.IdeManagement
{
    public class IdeProcessManagement(
        IIdeExecutiveFileLocation ideExecutiveFileLocation,
        ILogger<IdeProcessManagement> logger,
        IProcessesMetaDataDirectory processesMetaDataDirectory,
        IApplicationLocation  applicationLocation,
        IIdeName ideName,
        IApplicationName applicationName
    ): IIdeProcessManagement
    {
        private readonly IIdeExecutiveFileLocation ideExecutiveFileLocation = ideExecutiveFileLocation;
        private readonly IProcessesMetaDataDirectory processesMetaDataDirectory = processesMetaDataDirectory;
        private readonly IApplicationLocation applicationLocation = applicationLocation;

        public void Open()
        {
                IdeProcessInformationGroup ideProcessInformationGroup = new();

                var pro = this.StartProcess();

                var processesMetaDataDirectory_path = processesMetaDataDirectory.GetPath();

                if (!Directory.Exists(processesMetaDataDirectory_path))
                {
                    Directory.CreateDirectory(processesMetaDataDirectory_path);
                }

                var ideManagementProcessesMetaDataFile = Path.Combine(processesMetaDataDirectory_path, "ide-management-processes-meta-data.json");

                if(File.Exists(ideManagementProcessesMetaDataFile))
                {
                    using StreamReader r = new(ideManagementProcessesMetaDataFile);
                    var json = r.ReadToEnd();
                    r.Close();
                    var ideProcessInformationGroup_json = Newtonsoft.Json.JsonConvert.DeserializeObject<IdeProcessInformationGroup>(json);
                    ideProcessInformationGroup_json?.AddInFront(pro);
                    var ideProcessInformationGroup_Serialized1 = JsonSerializer.Serialize(ideProcessInformationGroup_json);
                    File.WriteAllText(ideManagementProcessesMetaDataFile, ideProcessInformationGroup_Serialized1);
                }
                else
                {
                    ideProcessInformationGroup.Add(pro);
                    var ideProcessInformationGroup_Serialized1 = JsonSerializer.Serialize(ideProcessInformationGroup);
                    File.WriteAllText(ideManagementProcessesMetaDataFile, ideProcessInformationGroup_Serialized1);
                }
        }

        public void Close()
        {
            var ideManagementProcessesMetaDataFile = Path.Combine(processesMetaDataDirectory.GetPath(), "ide-management-processes-meta-data.json");

            using StreamReader r = new(ideManagementProcessesMetaDataFile);
            var json = r.ReadToEnd();
            var ideProcessInformationGroup_json = Newtonsoft.Json.JsonConvert.DeserializeObject<IdeProcessInformationGroup>(json);


            var ideProcessInformation_selected = ideProcessInformationGroup_json?
                .Group?
                .Where(
                    ideProcessInformation =>  ideProcessInformation.IdeName == ideName.GetName()
                    && ideProcessInformation.ApplicationName == applicationName.GetName()
                )
                .ToList()
                .First();

            logger.LogInformation("ApplicationName, {ApplicationName}", ideProcessInformation_selected?.ApplicationName);
            logger.LogInformation("IdeName, {IdeName}", ideProcessInformation_selected?.IdeName);
            logger.LogInformation("Id, {Id}", ideProcessInformation_selected?.Id);

            var p = Process.GetProcessById((int)(ideProcessInformation_selected?.Id ?? 0));
            p.Kill();

            var ideProcessInformation_selected_2 = ideProcessInformationGroup_json?.Group
                ?.SingleOrDefault(
                    ideProcessInformation =>  ideProcessInformation.IdeName == ideName.GetName()
                    && ideProcessInformation.ApplicationName == applicationName.GetName()
                );

            if (ideProcessInformation_selected_2 != null)
            {
                ideProcessInformationGroup_json?.Group?.Remove(ideProcessInformation_selected_2);
                var ideProcessInformationGroup_Serialized1 = JsonSerializer.Serialize(ideProcessInformationGroup_json);
                File.WriteAllText(ideManagementProcessesMetaDataFile, ideProcessInformationGroup_Serialized1);
            }
        }


        private IdeProcessInformation StartProcess()
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
            IdeProcessInformation ideProcessInformation = new() 
            { 
                GroupName = "ide",
                Id = myProcess.Id,
                IdeName = ideName.GetName(),
                ApplicationName= applicationName.GetName()
            };
            return ideProcessInformation;
        }
    }

    public interface IIdeProcessManagement
    {
        public void Open();
        public void Close();

    }
}