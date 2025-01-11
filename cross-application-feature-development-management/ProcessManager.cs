using System.Diagnostics;
using System.Text.Json;
using cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;
using cross_application_feature_development_management.Dirctories.Feature.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Dirctories.Feature.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Files.Interfaces;
using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management
{
    public class ProcessManager(
        INotePadPlusPlus notePadPlusPlus,
        ILogger<ProcessManager> logger,
        IDirectoryOperations directoryOperations,
        IFeatureNameDirectory featureNameDirectory,
        IFrontEndHostDirectory frontEndHostDirectory,
        IFrontEndGuestDirectory frontEndGuestDirectory,
        INotesAndMessagesDirectory notesAndMessagesDirectory,
        IProcessesMetaDataDirectory processesMetaDataDirectory,
        ICommandLineArgs commandLineArgs
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
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public void Run()
        {
            try
            {
                var a = frontEndHostDirectory.GetPath("FEND_HOST_ADDRESS");
                var b = frontEndGuestDirectory.GetPath("FEND_GUEST_ADDRESS");
                var c = notesAndMessagesDirectory.GetPath("NOTES_MESSAGES_ADDRESS");
                ProccessInformationGroup processInformationGroup = new();


                var orderValue = commandLineArgs.GetByKey("--order");

                if (orderValue == "reverse")
                {
                    this.StartProcess(b, processInformationGroup);
                    Thread.Sleep(3000);
                    this.StartProcess(a, processInformationGroup);
                    Thread.Sleep(3000);
                    this.StartProcess(c, processInformationGroup);
                }
                else
                {
                    this.StartProcess(a, processInformationGroup);
                    Thread.Sleep(3000);
                    this.StartProcess(b, processInformationGroup);
                    Thread.Sleep(3000);
                    this.StartProcess(c, processInformationGroup);
                }

                logger.LogInformation("Process information group: {processInformationGroup}", JsonSerializer.Serialize(processInformationGroup));

                var dddd = JsonSerializer.Serialize(processInformationGroup);
                logger.LogInformation("Process information group: {processInformationGroup}", dddd);
                var x = processesMetaDataDirectory.GetPath();

                if (!Directory.Exists(x))
                {
                    Directory.CreateDirectory(x);
                }

                var notepadPlusPlusFileProcessesMetaDataDirectory = Path.Combine(x, "notepad-plus-plus-file-processes-meta-data.json");
                File.WriteAllText(notepadPlusPlusFileProcessesMetaDataDirectory, dddd);

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
            var json = r.ReadToEnd();
            ProccessInformationGroup? items = Newtonsoft.Json.JsonConvert.DeserializeObject<ProccessInformationGroup>(json);
        }

        private void StartProcess(string openeeFilesContainingDirectoryLocation, ProccessInformationGroup processInformationGroup)
        {
            try
            {
                var executiveFileLocation = notePadPlusPlus.GetPath();

                using Process myProcess = new();
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = executiveFileLocation;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.ArgumentList.Add("-multiInst");
                myProcess.StartInfo.ArgumentList.Add("-nosession");
                foreach (var file in Directory.EnumerateFiles(openeeFilesContainingDirectoryLocation))
                {
                    myProcess.StartInfo.ArgumentList.Add(file);
                }
                myProcess.Start();
                logger.LogInformation("Process id: {Id}", myProcess.Id);
                DirectoryInfo directoryInfo = new(openeeFilesContainingDirectoryLocation);
                var dirName = directoryInfo.Name;
                ProccessInformation processInformation = new() { GroupName = dirName, Id = myProcess.Id };
                processInformationGroup.AddInFront(processInformation);

            }
            catch (Exception e)
            {
                logger.LogInformation("{Message}", e.Message);
            }
        }
    }
}