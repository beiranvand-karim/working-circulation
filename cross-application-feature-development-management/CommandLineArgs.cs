using cross_application_feature_development_management.Interfaces;
using Microsoft.Extensions.Configuration;

namespace cross_application_feature_development_management
{
    public class CommandLineArgs(IConfiguration configuration): ICommandLineArgs
    {
        private readonly IConfiguration configuration = configuration;

        public string GetKey(string key)
        {
            const string groupKey = "EnvironmentVariablesCommandLineArgumentsNameKeys";
            var commandLineArgumentKey = $"{groupKey}:{key}";
            return configuration.GetValue<string>(commandLineArgumentKey) ?? $"""couldn't find key "{key}" ...""";
        }

        public string GetKey2(string groupKey, string key)
        {
            var commandLineArgumentKey = $"{groupKey}:{key}";
            return configuration.GetValue<string>(commandLineArgumentKey) ?? $"""couldn't find key "{key}" ...""";
        }

        public string GetByKey(string commandLineArgKey)
        {
            var commandLineArgs = Environment.GetCommandLineArgs();

            var index = Array.FindIndex(commandLineArgs, x => x.StartsWith(commandLineArgKey));
            if (index > -1)
            {
                var commandLineArgValue = commandLineArgs[index + 1];
                return commandLineArgValue;
            }

            return $"""couldn't find environment variable "{commandLineArgKey}" ...""";
        }
    }
}