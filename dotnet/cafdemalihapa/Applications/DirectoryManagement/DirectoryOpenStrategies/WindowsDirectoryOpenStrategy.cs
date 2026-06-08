using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Applications.DirectoryManagement.DirectoryOpenStrategies
{
    public class WindowsDirectoryOpenStrategy(ILogger<WindowsDirectoryOpenStrategy> logger)
        : DirectoryOpenStrategy(logger)
    {
        protected override string FileName => "explorer.exe";

        protected override string TransformPath(string path) =>
            path.NormalizeSlashes(PathUtility.SlashStyle.ForceBackslash);

        public override bool CanHandle() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
}
