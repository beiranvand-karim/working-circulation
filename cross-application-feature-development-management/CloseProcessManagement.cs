using System.Diagnostics;
using cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management
{
    public class CloseProcessManagement(
        ILogger<CloseProcessManagement> logger,
        IProcessesMetaDataDirectory processesMetaDataDirectory
        ) : ICloseProcessManagement
    {
        private readonly ILogger<CloseProcessManagement> logger = logger;
        private readonly IProcessesMetaDataDirectory processesMetaDataDirectory = processesMetaDataDirectory;

        public void Run()
        {
            var notepadPlusPlusFileProcessesMetaDataDirectory = Path.Combine(processesMetaDataDirectory.GetPath(), "notepad-plus-plus-file-processes-meta-data.json");

            using StreamReader r = new(notepadPlusPlusFileProcessesMetaDataDirectory);
            var json = r.ReadToEnd();
            ProccessInformationGroup? readProcessInformationGroup = Newtonsoft.Json.JsonConvert.DeserializeObject<ProccessInformationGroup>(json);

            logger.LogInformation("items, {items}", readProcessInformationGroup);

            foreach (var pInfo in readProcessInformationGroup?.Group)
            {
                logger.LogInformation("Id: {Id}", pInfo?.Id);
                var p = Process.GetProcessById((int)pInfo?.Id);
                p.Kill();
                Thread.Sleep(2000);
            }

        }

    }

    public interface ICloseProcessManagement
    {
        public void Run();
    }
}