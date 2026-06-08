using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Applications.DirectoryManagement.DirectoryOpenStrategies
{
    public class LinuxDirectoryOpenStrategy(ILogger<LinuxDirectoryOpenStrategy> logger)
        : DirectoryOpenStrategy(logger)
    {
        protected override string FileName => "xdg-open";

        public override bool CanHandle() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
}
