using Microsoft.Extensions.Logging;

namespace cafdemalihapa.Directories.Applications
{
    public class ApplicationLocation(
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