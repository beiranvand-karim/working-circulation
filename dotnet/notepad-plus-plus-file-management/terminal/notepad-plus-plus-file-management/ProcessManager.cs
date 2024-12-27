using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using notepad_plus_plus_file_management.Dirctories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;
using notepad_plus_plus_file_management.Dirctories.Interfaces;
using notepad_plus_plus_file_management.Files.Executabes.Interfaces;

namespace notepad_plus_plus_file_management
{
    public class ProcessManager(
        INotePadPlusPlus notePadPlusPlus,
        ILogger<ProcessManager> logger,
        IDirectoryOperations directoryOperations,
        IFeatureNameDirectory featureNameDirectory,
        IFrontEndHostDirectory frontEndHostDirectory,
        IFrontEndGuestDirectory frontEndGuestDirectory,
        INotesAndMessagesDirectory notesAndMessagesDirectory,
        IProcessesMetaDataDirectory processesMetaDataDirectory
        ) : IProcessManager
    {
        private readonly INotePadPlusPlus notePadPlusPlus = notePadPlusPlus;
        private readonly ILogger<ProcessManager> logger = logger;
        private readonly IDirectoryOperations directoryOperations = directoryOperations;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly IFrontEndHostDirectory frontEndHostDirectory = frontEndHostDirectory;
        private readonly IFrontEndGuestDirectory frontEndGuestDirectory = frontEndGuestDirectory;
        private readonly INotesAndMessagesDirectory notesAndMessagesDirectory = notesAndMessagesDirectory;
        private readonly IProcessesMetaDataDirectory processesMetaDataDirectory = processesMetaDataDirectory;

        public void Run()
        {
            try
            {
                var a = frontEndHostDirectory.GetPath("FEND_HOST_ADDRESS");
                var b = frontEndGuestDirectory.GetPath("FEND_GUEST_ADDRESS");
                var c = notesAndMessagesDirectory.GetPath("NOTES_MESSAGES_ADDRESS");
                ProccessInformationGroup proccessInformationGroup = new();


                this.StartProcess(a, proccessInformationGroup);
                Thread.Sleep(5000);
                this.StartProcess(b, proccessInformationGroup);
                Thread.Sleep(5000);
                this.StartProcess(c, proccessInformationGroup);
                Thread.Sleep(5000);

                logger.LogInformation("Proccess information group: {proccessInformationGroup}", JsonSerializer.Serialize(proccessInformationGroup));

                var dddd = System.Text.Json.JsonSerializer.Serialize(proccessInformationGroup);
                logger.LogInformation("Proccess information group: {proccessInformationGroup}", dddd);
                var notepadPlusPlusFileProcessesMetaDataDirectory = Path.Combine(processesMetaDataDirectory.GetPath(), "notepad-plus-plus-file-processes-meta-data.json");
                File.WriteAllText(notepadPlusPlusFileProcessesMetaDataDirectory, dddd);

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
            catch (Exception e)
            {
                logger.LogInformation("{Message}", e.Message);
            }
        }

        public void LoadJson()
        {
            var notepadPlusPlusFileProcessesMetaDataDirectory = Path.Combine(processesMetaDataDirectory.GetPath(), "notepad-plus-plus-file-processes-meta-data.json");
            using StreamReader r = new(notepadPlusPlusFileProcessesMetaDataDirectory);
            string json = r.ReadToEnd();
            ProccessInformationGroup? items = Newtonsoft.Json.JsonConvert.DeserializeObject<ProccessInformationGroup>(json);
        }

        public void StartProcess(string openeeFilesContainingDirectoryLocation, ProccessInformationGroup proccessInformationGroup)
        {
            try
            {
                string exceutiveFileLocation = notePadPlusPlus.GetPath();

                using Process myProcess = new();
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = exceutiveFileLocation;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.ArgumentList.Add("-multiInst");
                myProcess.StartInfo.ArgumentList.Add("-nosession");
                foreach (string file in Directory.EnumerateFiles(openeeFilesContainingDirectoryLocation))
                {
                    myProcess.StartInfo.ArgumentList.Add(file);
                }
                myProcess.Start();
                logger.LogInformation("Process id: {Id}", myProcess.Id);
                DirectoryInfo directoryInfo = new(openeeFilesContainingDirectoryLocation);
                string dirName = directoryInfo.Name;
                ProccessInformation proccessInformation = new() { GroupName = dirName, Id = myProcess.Id };
                proccessInformationGroup.AddInFront(proccessInformation);

            }
            catch (Exception e)
            {
                logger.LogInformation("{Message}", e.Message);
            }
        }
    }
}