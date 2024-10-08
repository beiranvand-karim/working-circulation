using System.Diagnostics;
using Microsoft.Extensions.Logging;
using notepad_plus_plus_file_management.Dirctories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;

namespace notepad_plus_plus_file_management
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
            string json = r.ReadToEnd();
            ProccessInformationGroup? readProccessInformationGroup = Newtonsoft.Json.JsonConvert.DeserializeObject<ProccessInformationGroup>(json);

            logger.LogInformation("items, {items}", readProccessInformationGroup);

            foreach (var pInfo in readProccessInformationGroup?.Group)
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