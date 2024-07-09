using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace configuration_system
{
    public class GreetingService(ILogger<GreetingService> log, IConfiguration config) : IGreetingService
    {
        private readonly ILogger<GreetingService> log = log;
        private readonly IConfiguration config = config;

        public void Run()
        {
            for (int i = 0; i < config.GetValue<int>("LoopTimes"); i++)
            {
                log.LogInformation("Run number {runNumber}", i);
            }
        }

    }
}