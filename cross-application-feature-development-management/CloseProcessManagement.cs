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

    }

    public interface ICloseProcessManagement
    {
        public void Run();
    }
}