using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Applications
{
    public class ApplicationLocation(
        IConfiguration configuration,
        ICommandLineArgs commandLineArgs,
        ILogger<ApplicationLocation> logger
    )
    {
        private readonly IConfiguration configuration = configuration;

        public string GetPath()
        {
            var applicationLocation = commandLineArgs.GetByKey("--application-location");
            logger.LogInformation("application location: {applicationLocation}", applicationLocation);
            return applicationLocation;
        }

    }

    public interface  IApplicationLocation
    {
        public string GeetePath();
    }
}