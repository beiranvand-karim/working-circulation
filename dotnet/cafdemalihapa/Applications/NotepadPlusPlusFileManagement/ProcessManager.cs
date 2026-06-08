using System.Diagnostics;
using System.Text.Json;
using cafdemalihapa.Directories.Hosting.Feature.Automations.ProcessesMetaData;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndGuest;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndHost;
using cafdemalihapa.Directories.Hosting.Feature.NotesAndMessages;
using cafdemalihapa.Files.Executables;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Applications.NotepadPlusPlusFileManagement
{
    public class ProcessManager(
        NotepadPlusPlus notePadPlusPlus,
        ILogger<ProcessManager> logger,
        FrontEndHostDirectory frontEndHostDirectory,
        FrontEndGuestDirectory frontEndGuestDirectory,
        NotesAndMessagesDirectory notesAndMessagesDirectory,
        ProcessesMetaDataDirectory processesMetaDataDirectory
        )
    {
        public void Run()
        {
            try
            {
                var a = frontEndHostDirectory.GetPath();
                var b = frontEndGuestDirectory.GetPath();
                var c = notesAndMessagesDirectory.GetPath();
                ProcessInformationGroup processInformationGroup = new();


                var orderValue = CommandLineArgs.GetByKey("--order");

                if (orderValue == "reverse")
                {
                    this.StartProcess(b, processInformationGroup);
                    Thread.Sleep(100);
                    this.StartProcess(a, processInformationGroup);
                    Thread.Sleep(100);
                    this.StartProcess(c, processInformationGroup);
                }
                else
                {
                    this.StartProcess(a, processInformationGroup);
                    Thread.Sleep(100);
                    this.StartProcess(b, processInformationGroup);
                    Thread.Sleep(100);
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
                logger.LogInformation("ProcessManager: {Message}", e.Message);
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