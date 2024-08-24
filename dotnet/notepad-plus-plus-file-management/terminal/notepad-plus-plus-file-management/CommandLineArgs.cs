using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Configuration;

namespace cross_application_feature_development_management
{
    public class CommandLineArgs(IConfiguration configuration) : ICommandLineArgs
    {
        private readonly IConfiguration configuration = configuration;

        public string GetByKey(string CommandLineArgKey)
        {
            var commandLineArgs = Environment.GetCommandLineArgs();

            int index = Array.FindIndex(commandLineArgs, x => x.StartsWith(CommandLineArgKey));
            if (index > -1)
            {
                string CommandLineArgValue = commandLineArgs[index + 1];
                return CommandLineArgValue;
            }

            return $"""could'nt find environment variable "{CommandLineArgKey}" ...""";
        }
    }
}