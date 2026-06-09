using cafdemalihapa.Directories.Hosting.Feature.BackEnd;
using cafdemalihapa.Directories.Hosting.Feature.BackEnd.BackEndPrimary;
using cafdemalihapa.Directories.Hosting.Feature.BackEnd.BackEndSecondary;
using cafdemalihapa.Directories.Hosting.Feature.Calls;
using cafdemalihapa.Directories.Hosting.Feature.Data;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndSecondary;
using cafdemalihapa.Directories.Hosting.Feature.FrontEnd.FrontEndPrimary;
using cafdemalihapa.Directories.Hosting.Feature.NotesAndMessages;
using cafdemalihapa.Directories.Hosting.Feature.Tools;
using cafdemalihapa.Directories.Hosting.Feature.WebLinks;

namespace cafdemalihapa.Applications.DirectoryManagement
{
    public class Creation
    (
        DataDirectory dataDirectory,
        ToolsDirectory toolsDirectory,
        BackEndPrimaryDirectory backEndPrimaryDirectory,
        BackEndSecondaryDirectory backEndSecondaryDirectory,
        CallsDirectory callsDirectory,
        FrontEndDirectory frontEndDirectory,
        FrontEndPrimaryDirectory frontEndPrimaryDirectory,
        FrontEndSecondaryDirectory frontEndSecondaryDirectory,
        NotesAndMessagesDirectory notesAndMessagesDirectory,
        WebLinksDirectory webLinksDirectory
    )
    {
        public void Create()
        {
            if (!Commands.Get().IsCreate())
            {
                return;
            }
            CreateDirectories();
            CreateFiles();
        }

        public void CreateDirectories()
        {
            var directoriesToCreate = new List<Action>
            {
                toolsDirectory.Create,
                BackEndDirectory.Create,
                backEndPrimaryDirectory.Create,
                backEndSecondaryDirectory.Create,
                callsDirectory.Create,
                dataDirectory.Create,
                frontEndDirectory.Create,
                frontEndPrimaryDirectory.Create,
                frontEndSecondaryDirectory.Create,
                notesAndMessagesDirectory.Create,
                webLinksDirectory.Create,
            };

            foreach (var create in directoriesToCreate)
            {
                create();
            }
        }

        public void CreateFiles()
        {
            var filesToCreate = new List<Action>
            {
                frontEndPrimaryDirectory.CreateFiles,
                frontEndSecondaryDirectory.CreateFiles,
                notesAndMessagesDirectory.CreateFiles,
            };

            foreach (var createFiles in filesToCreate)
            {
                createFiles();
            }
        }
    }
}
