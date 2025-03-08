using System.Diagnostics;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management
{
    public class CloseProcessManagement(
        ILogger<CloseProcessManagement> logger,
        ProcessesMetaDataDirectory processesMetaDataDirectory
        )
    {
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
            }
        }
    }
}