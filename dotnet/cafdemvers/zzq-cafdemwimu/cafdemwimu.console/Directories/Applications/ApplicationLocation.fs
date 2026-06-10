namespace cafdemwimu.console.Directories.Applications

open Microsoft.Extensions.Logging
open cafdemwimu.console

type ApplicationLocation(logger: ILogger<ApplicationLocation>) =
    member _.GetPath() =
        let applicationLocation = CommandLineArgs.GetByKey("--application-location")
        logger.LogInformation("application location: {applicationLocation}", applicationLocation)
        applicationLocation
