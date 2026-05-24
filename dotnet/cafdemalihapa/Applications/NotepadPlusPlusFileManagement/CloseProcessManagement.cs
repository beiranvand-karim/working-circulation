using System.Diagnostics;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.ProcessesMetaDataDirectory;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Applications.NotepadPlusPlusFileManagement
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

            foreach (var pInfo in readProcessInformationGroup?.Group)
            {
                logger.LogInformation("Id: {Id}", pInfo?.Id);
                var p = Process.GetProcessById((int)pInfo?.Id);
                p.Kill();
            }
        }
    }
}