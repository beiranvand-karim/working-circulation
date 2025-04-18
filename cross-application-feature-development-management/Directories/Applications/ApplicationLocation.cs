using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace cross_application_feature_development_management.Directories.Applications
{
    public class ApplicationLocation(
        IConfiguration configuration,
        CommandLineArgs commandLineArgs,
        ILogger<ApplicationLocation> logger
    )
    {
        public string GetPath()
        {
            var applicationLocation = CommandLineArgs.GetByKey("--application-location");
            logger.LogInformation("application location: {applicationLocation}", applicationLocation);
            return applicationLocation;
        }
    }
}