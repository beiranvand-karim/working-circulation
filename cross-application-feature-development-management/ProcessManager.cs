using System.Diagnostics;
using System.Text.Json;
using cross_application_feature_development_management.Directories;
using cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndGuestDirectory;
using cross_application_feature_development_management.Directories.Feature.FrontEndDirectory.FrontEndHostDirectory;
using cross_application_feature_development_management.Files.Executables;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management
{
    public class ProcessManager(
        NotePadPlusPlus notePadPlusPlus,
        ILogger<ProcessManager> logger,
        DirectoryOperations directoryOperations,
        FeatureNameDirectory featureNameDirectory,
        FrontEndHostDirectory frontEndHostDirectory,
        FrontEndGuestDirectory frontEndGuestDirectory,
        NotesAndMessagesDirectory notesAndMessagesDirectory,
        ProcessesMetaDataDirectory processesMetaDataDirectory,
        CommandLineArgs commandLineArgs
        )
    {
        public void Run()
        {
            try
            {
                var a = frontEndHostDirectory.GetPath("FEND_HOST_ADDRESS");
                var b = frontEndGuestDirectory.GetPath("FEND_GUEST_ADDRESS");
                var c = notesAndMessagesDirectory.GetPath("NOTES_MESSAGES_ADDRESS");
                ProcessInformationGroup processInformationGroup = new();


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
            var items = Newtonsoft.Json.JsonConvert.DeserializeObject<ProcessInformationGroup>(json);
        }

        private void StartProcess(string openeeFilesContainingDirectoryLocation, ProcessInformationGroup processInformationGroup)
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
                ProcessInformation processInformation = new() { GroupName = dirName, Id = myProcess.Id };
                processInformationGroup.AddInFront(processInformation);

            }
            catch (Exception e)
            {
                logger.LogInformation("{Message}", e.Message);
            }
        }
    }
}