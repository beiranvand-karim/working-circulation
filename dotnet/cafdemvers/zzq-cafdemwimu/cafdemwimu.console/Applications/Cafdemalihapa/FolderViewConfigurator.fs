namespace cafdemwimu.console.Applications.Cafdemalihapa

open System
open System.IO
open System.Threading
open System.Reflection
open System.Runtime.Versioning
open cafdemwimu.console.Directories.Hosting.Feature.Automations.Commands
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles

// F# has no `dynamic`; the source's COM late-binding is reproduced with reflection.
module private ComLateBinding =
    let invokeMethod (target: obj) (name: string) (args: obj[]) =
        target.GetType().InvokeMember(name, BindingFlags.InvokeMethod, null, target, args)

    let getProp (target: obj) (name: string) =
        target.GetType().InvokeMember(name, BindingFlags.GetProperty, null, target, [||])

    let setProp (target: obj) (name: string) (value: obj) =
        target.GetType().InvokeMember(name, BindingFlags.SetProperty, null, target, [| value |]) |> ignore

type FolderViewConfigurator
    (
        commandsDirectory: CommandsDirectory,
        environmentVariablesFilesDirectory: EnvironmentVariablesFilesDirectory
    ) =
    // Canonical property for the file name column.
    let nameProperty = "System.ItemNameDisplay"

    // Explorer view modes (FOLDERVIEWMODE). List = 3.
    let listViewMode = 3

    // Waits for the Explorer window for the given path to appear, then returns it.
    [<SupportedOSPlatform("windows")>]
    member private _.FindWindow(shell: obj, normalizedPath: string) : obj =
        let deadline = DateTime.Now.AddSeconds(10.0)
        let mutable result : obj = null

        while isNull result && DateTime.Now < deadline do
            let windows = ComLateBinding.invokeMethod shell "Windows" [||]
            let count = ComLateBinding.getProp windows "Count" :?> int

            let mutable index = 0
            while isNull result && index < count do
                let candidate = ComLateBinding.invokeMethod windows "Item" [| box index |]
                if not (isNull candidate) then
                    let locationUrl = ComLateBinding.getProp candidate "LocationURL" :?> string
                    if not (String.IsNullOrEmpty(locationUrl)) then
                        let location = Uri(locationUrl).LocalPath.TrimEnd('\\')
                        if String.Equals(location, normalizedPath, StringComparison.OrdinalIgnoreCase) then
                            result <- candidate
                index <- index + 1

            // Not ready yet — wait briefly and poll again.
            if isNull result then
                Thread.Sleep(50)

        result

    // Configures a directory's Explorer view: files sorted ascending by
    // name, grouped by name, with the view type set to List.
    [<SupportedOSPlatform("windows")>]
    member private this.ConfigureFolderView(path: string) =
        let normalizedPath = Path.GetFullPath(path).TrimEnd('\\')

        let shellType = Type.GetTypeFromProgID("Shell.Application")
        if isNull shellType then
            ()
        else
            let shell = Activator.CreateInstance(shellType)

            // Open the folder so we get a live Explorer view to configure.
            ComLateBinding.invokeMethod shell "Open" [| box normalizedPath |] |> ignore

            let window = this.FindWindow(shell, normalizedPath)
            if isNull window then
                ()
            else
                // Hide the window as early as possible so the folder isn't shown.
                ComLateBinding.setProp window "Visible" (box false)

                let view = ComLateBinding.getProp window "Document"

                // View type: List.
                ComLateBinding.setProp view "CurrentViewMode" (box listViewMode)

                // Sort ascending by name ('+' = ascending).
                ComLateBinding.setProp view "SortColumns" (box $"prop:+{nameProperty}")

                // Group by name.
                ComLateBinding.setProp view "GroupBy" (box nameProperty)

                // Give Explorer a moment to apply and persist the view settings,
                // then close the window. Windows saves the per-folder view to its
                // ShellBag on close.
                Thread.Sleep(500)
                ComLateBinding.invokeMethod window "Quit" [||] |> ignore

    member this.Configure() =
        if not (OperatingSystem.IsWindows()) then
            ()
        else
            this.ConfigureFolderView(commandsDirectory.GetPath())
            this.ConfigureFolderView(environmentVariablesFilesDirectory.GetPath())
