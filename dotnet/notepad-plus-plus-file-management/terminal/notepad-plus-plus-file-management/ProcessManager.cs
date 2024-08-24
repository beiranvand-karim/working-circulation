using System.Diagnostics;
using Microsoft.Extensions.Logging;
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
        INotesAndMessagesDirectory notesAndMessagesDirectory
        ) : IProcessManager
    {
        private readonly INotePadPlusPlus notePadPlusPlus = notePadPlusPlus;
        private readonly ILogger<ProcessManager> logger = logger;
        private readonly IDirectoryOperations directoryOperations = directoryOperations;
        private readonly IFeatureNameDirectory featureNameDirectory = featureNameDirectory;
        private readonly IFrontEndHostDirectory frontEndHostDirectory = frontEndHostDirectory;
        private readonly IFrontEndGuestDirectory frontEndGuestDirectory = frontEndGuestDirectory;
        private readonly INotesAndMessagesDirectory notesAndMessagesDirectory = notesAndMessagesDirectory;

        public void Run()
        {
            try
            {
                var a = frontEndHostDirectory.GetPath("FEND_HOST_ADDRESS");
                var b = frontEndGuestDirectory.GetPath("FEND_GUEST_ADDRESS");
                var c = notesAndMessagesDirectory.GetPath("NOTES_MESSAGES_ADDRESS");

                this.StartProcess(a);
                Thread.Sleep(5000);
                this.StartProcess(b);
                Thread.Sleep(5000);
                this.StartProcess(c);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                logger.LogInformation("{Message}", e.Message);
            }
        }

        public void StartProcess(string openeeFilesContainingDirectoryLocation)
        {
            try
            {
                string exceutiveFileLocation = notePadPlusPlus.GetPath();

                using Process myProcess = new();
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = exceutiveFileLocation;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.ArgumentList.Add("-multiInst");
                foreach (string file in Directory.EnumerateFiles(openeeFilesContainingDirectoryLocation))
                {
                    myProcess.StartInfo.ArgumentList.Add(file);
                }
                myProcess.Start();

            }
            catch (Exception e)
            {
                logger.LogInformation("{Message}", e.Message);
            }
        }
    }
}