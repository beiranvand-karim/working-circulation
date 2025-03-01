using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Files.Executables
{
    public class IdeExecutiveFileLocation(
        IConfiguration configuration,
        ICommandLineArgs commandLineArgs,
        ILogger<IdeExecutiveFileLocation> logger
    ): IIdeExecutiveFileLocation
    {
        private readonly IConfiguration configuration = configuration;
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        private readonly ILogger<IdeExecutiveFileLocation> logger = logger;

        public string GetPath()
        {
            var ideExecuteFileLocation = commandLineArgs.GetByKey("--ide-execute-file-location");
            logger.LogInformation("ide execute file location: {ideExecuteFileLocation}", ideExecuteFileLocation);
            return ideExecuteFileLocation;
        }

    }
    public interface IIdeExecutiveFileLocation
    {
        public string GetPath();
    }
}