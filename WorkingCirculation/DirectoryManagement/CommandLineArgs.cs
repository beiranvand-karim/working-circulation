using Microsoft.Extensions.Configuration;

namespace DirectoryManagement
{
    public class CommandLineArgs(IConfiguration configuration) : ICommandLineArgs
    {
        private readonly IConfiguration configuration = configuration;

        public string GetKey(string key)
        {
            string groupKey = "EnvironmentVariablesCommandLineArgumentsNameKeys";
            string commandLineArgumentKey = $""""{groupKey}:{key}"""";
            return configuration.GetValue<string>(commandLineArgumentKey) ?? $"""could'nt find key "{key}" ...""";
        }

        public string GetKey2(string groupKey, string key)
        {
            string commandLineArgumentKey = $""""{groupKey}:{key}"""";
            return configuration.GetValue<string>(commandLineArgumentKey) ?? $"""could'nt find key "{key}" ...""";
        }

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