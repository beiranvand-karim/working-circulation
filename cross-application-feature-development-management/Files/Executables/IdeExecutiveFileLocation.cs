using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Files.Executables
{
    public class IdeExecutiveFileLocation(
        IConfiguration configuration,
        CommandLineArgs commandLineArgs,
        ILogger<IdeExecutiveFileLocation> logger
    )
    {
        public string GetPath()
        {
            var ideExecuteFileLocation = CommandLineArgs.GetByKey("--ide-execute-file-location");
            logger.LogInformation("ide execute file location: {ideExecuteFileLocation}", ideExecuteFileLocation);
            return ideExecuteFileLocation;
        }
    }
}