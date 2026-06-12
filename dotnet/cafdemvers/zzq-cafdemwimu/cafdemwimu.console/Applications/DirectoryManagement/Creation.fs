namespace cafdemwimu.console.Applications.DirectoryManagement

open cafdemwimu.console.Applications
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndPrimary
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndSecondary
open cafdemwimu.console.Directories.Hosting.Feature.BackEnd.BackEndTertiary
open cafdemwimu.console.Directories.Hosting.Feature.Calls
open cafdemwimu.console.Directories.Hosting.Feature.Data
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndPrimary
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndSecondary
open cafdemwimu.console.Directories.Hosting.Feature.FrontEnd.FrontEndTertiary
open cafdemwimu.console.Directories.Hosting.Feature.NotesAndMessages
open cafdemwimu.console.Directories.Hosting.Feature.Tools
open cafdemwimu.console.Directories.Hosting.Feature.WebLinks

type Creation
    (
        dataDirectory: DataDirectory,
        toolsDirectory: ToolsDirectory,
        backEndPrimaryDirectory: BackEndPrimaryDirectory,
        backEndSecondaryDirectory: BackEndSecondaryDirectory,
        backEndTertiaryDirectory: BackEndTertiaryDirectory,
        callsDirectory: CallsDirectory,
        frontEndDirectory: FrontEndDirectory,
        frontEndPrimaryDirectory: FrontEndPrimaryDirectory,
        frontEndSecondaryDirectory: FrontEndSecondaryDirectory,
        frontEndTertiaryDirectory: FrontEndTertiaryDirectory,
        notesAndMessagesDirectory: NotesAndMessagesDirectory,
        webLinksDirectory: WebLinksDirectory
    ) =
    member this.Create() =
        if Commands.Get().IsCreate() then
            this.CreateDirectories()
            this.CreateFiles()

    member _.CreateDirectories() =
        let directoriesToCreate: (unit -> unit) list =
            [ (fun () -> toolsDirectory.Create())
              (fun () -> BackEndDirectory.Create())
              (fun () -> backEndPrimaryDirectory.Create())
              (fun () -> backEndSecondaryDirectory.Create())
              (fun () -> backEndTertiaryDirectory.Create())
              (fun () -> callsDirectory.Create())
              (fun () -> dataDirectory.Create())
              (fun () -> frontEndDirectory.Create())
              (fun () -> frontEndPrimaryDirectory.Create())
              (fun () -> frontEndSecondaryDirectory.Create())
              (fun () -> frontEndTertiaryDirectory.Create())
              (fun () -> notesAndMessagesDirectory.Create())
              (fun () -> webLinksDirectory.Create()) ]

        for create in directoriesToCreate do
            create ()

    member _.CreateFiles() =
        let filesToCreate: (unit -> unit) list =
            [ (fun () -> frontEndPrimaryDirectory.CreateFiles())
              (fun () -> frontEndSecondaryDirectory.CreateFiles())
              (fun () -> frontEndTertiaryDirectory.CreateFiles())
              (fun () -> notesAndMessagesDirectory.CreateFiles()) ]

        for createFiles in filesToCreate do
            createFiles ()
