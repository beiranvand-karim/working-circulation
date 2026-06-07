using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.BackEnd;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.BackEnd.BackEndPrimaryDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.BackEnd.BackEndSecondaryDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.Calls;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.DataDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndGuestDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.FrontEndDirectory.FrontEndHostDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.NotesAndMessages;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.Tools;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.WebLinks;

namespace cafdemalihapa.Applications.DirectoryManagement
{
    public class Creation
    (
        DataDirectory dataDirectory,
        ToolsDirectory toolsDirectory,
        BackEndDirectory backEndDirectory,
        BackEndPrimaryDirectory backEndPrimaryDirectory,
        BackEndSecondaryDirectory backEndSecondaryDirectory,
        CallsDirectory callsDirectory,
        FrontEndDirectory frontEndDirectory,
        FrontEndHostDirectory frontEndHostDirectory,
        FrontEndGuestDirectory frontEndGuestDirectory,
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
                backEndDirectory.Create,
                backEndPrimaryDirectory.Create,
                backEndSecondaryDirectory.Create,
                callsDirectory.Create,
                dataDirectory.Create,
                frontEndDirectory.Create,
                frontEndHostDirectory.Create,
                frontEndGuestDirectory.Create,
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
                frontEndHostDirectory.CreateFiles,
                frontEndGuestDirectory.CreateFiles,
                notesAndMessagesDirectory.CreateFiles,
            };

            foreach (var createFiles in filesToCreate)
            {
                createFiles();
            }
        }
    }
}
