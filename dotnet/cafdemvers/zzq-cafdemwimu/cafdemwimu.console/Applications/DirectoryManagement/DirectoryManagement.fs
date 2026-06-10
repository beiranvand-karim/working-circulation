namespace cafdemwimu.console.Applications.DirectoryManagement

open cafdemwimu.console.Applications

type DirectoryManagement(creation: Creation, opening: Opening, shutting: Shutting) =
    member _.Run() =
        if Applications.Get().IsDirectoryManagementApplication() then
            opening.OpenDirectoryToBeOpen()
            creation.Create()
            opening.Open()
            shutting.Shut()
