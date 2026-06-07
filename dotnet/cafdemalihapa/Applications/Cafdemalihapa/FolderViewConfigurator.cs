using System.Runtime.Versioning;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.CommandsDirectory;
using cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles;

namespace cafdemalihapa.Applications.Cafdemalihapa
{
    public class FolderViewConfigurator
    (
        CommandsDirectory commandsDirectory,
        EnvironmentVariablesFilesDirectory environmentVariablesFilesDirectory
    )
    {
        // Canonical property for the file name column.
        const string nameProperty = "System.ItemNameDisplay";

        // Explorer view modes (FOLDERVIEWMODE). List = 3.
        const int listViewMode = 3;

        public void Configure()
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            ConfigureFolderView(commandsDirectory.GetPath());
            ConfigureFolderView(environmentVariablesFilesDirectory.GetPath());
        }

        // Configures a directory's Explorer view: files sorted ascending by
        // name, grouped by name, with the view type set to List.
        [SupportedOSPlatform("windows")]
        private void ConfigureFolderView(string path)
        {
            var normalizedPath = Path.GetFullPath(path).TrimEnd('\\');

            var shellType = Type.GetTypeFromProgID("Shell.Application");
            if (shellType == null)
            {
                return;
            }

            dynamic shell = Activator.CreateInstance(shellType)!;

            // Open the folder so we get a live Explorer view to configure.
            shell.Open(normalizedPath);

            dynamic? window = FindWindow(shell, normalizedPath);
            if (window == null)
            {
                return;
            }

            // Hide the window as early as possible so the folder isn't shown.
            window.Visible = false;

            dynamic view = window.Document;

            // View type: List.
            view.CurrentViewMode = listViewMode;

            // Sort ascending by name ('+' = ascending).
            view.SortColumns = $"prop:+{nameProperty}";

            // Group by name.
            view.GroupBy = nameProperty;

            // Give Explorer a moment to apply and persist the view settings,
            // then close the window so the directory isn't left open. Windows
            // saves the per-folder view to its ShellBag on close.
            Thread.Sleep(500);
            window.Quit();
        }

        // Waits for the Explorer window for the given path to appear, then returns it.
        [SupportedOSPlatform("windows")]
        private static dynamic? FindWindow(dynamic shell, string normalizedPath)
        {
            var deadline = DateTime.Now.AddSeconds(10);
            while (DateTime.Now < deadline)
            {
                dynamic windows = shell.Windows();
                int count = windows.Count;
                for (var index = 0; index < count; index++)
                {
                    dynamic? candidate = windows.Item(index);
                    if (candidate == null)
                    {
                        continue;
                    }

                    string locationUrl = candidate.LocationURL;
                    if (string.IsNullOrEmpty(locationUrl))
                    {
                        continue;
                    }

                    var location = new Uri(locationUrl).LocalPath.TrimEnd('\\');
                    if (string.Equals(location, normalizedPath, StringComparison.OrdinalIgnoreCase))
                    {
                        return candidate;
                    }
                }

                // Not ready yet — wait briefly and poll again.
                Thread.Sleep(50);
            }

            return null;
        }
    }
}
