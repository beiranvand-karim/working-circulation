using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Applications.DirectoryManagement.DirectoryOpenStrategies
{
    public class MacDirectoryOpenStrategy(ILogger<MacDirectoryOpenStrategy> logger)
        : DirectoryOpenStrategy(logger)
    {
        protected override string FileName => "open";

        public override bool CanHandle() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
    }
}
