using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace notepad_plus_plus_file_management
{
    public class ProcessManager(INotePadPlusPlus notePadPlusPlus, ILogger<ProcessManager> logger, IDirectoryOperations directoryOperations) : IProcessManager
    {
        private readonly INotePadPlusPlus notePadPlusPlus = notePadPlusPlus;
        private readonly ILogger<ProcessManager> logger = logger;
        private readonly IDirectoryOperations directoryOperations = directoryOperations;

        public void Run()
        {

            try
            {
                string exceutiveFileLocation = notePadPlusPlus.GetExceutiveFileLocation();
                string openeeFilesContainingDirectoryLocation = notePadPlusPlus.GetOpeneeFilesContainingDirectoryLocation();
                logger.LogInformation("Exceutive file location: {exceutiveFileLocation}", exceutiveFileLocation);
                logger.LogInformation("Openee files containing directory location: {openeeFilesContainingDirectoryLocation}", openeeFilesContainingDirectoryLocation);

                directoryOperations.ListFilesToConsole(openeeFilesContainingDirectoryLocation);

                using Process myProcess = new();
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = exceutiveFileLocation;
                myProcess.StartInfo.CreateNoWindow = true;
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