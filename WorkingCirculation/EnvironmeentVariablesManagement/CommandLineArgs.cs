
using Microsoft.Extensions.Configuration;

namespace EnvironmentVariablesManagement
{
    internal class CommandLineArgs 
    {
        internal class DirectoriesNameToKeyMap
        {
            public static string GetValue(IConfiguration configuration, string key)
            {
                string groupKey = "DirectoriesNameToKeyMap";
                return GetKey2(configuration, groupKey, key);
            }
        }

        public static string GetKey(IConfiguration config,string key)
        {
            string groupKey = "EnvironmentVariablesCommandLineArgumentsNameKeys";
            string commandLineArgumentKey = $""""{groupKey}:{key}"""";
            return config.GetValue<string>(commandLineArgumentKey) ?? $"""could'nt find key "{key}" ...""";
        }

        public static string GetKey2(IConfiguration config, string groupKey, string key)
        {
            string commandLineArgumentKey = $""""{groupKey}:{key}"""";
            return config.GetValue<string>(commandLineArgumentKey) ?? $"""could'nt find key "{key}" ...""";
        }
        
        public static string GetByKey(string CommandLineArgKey)
        {
            var commandLineArgs = Environment.GetCommandLineArgs();

            int index = Array.FindIndex(commandLineArgs, x => x.StartsWith(CommandLineArgKey));
            if(index > -1)
            {
                string CommandLineArgValue = commandLineArgs[index+1];
                return CommandLineArgValue;
            }

            return $"""could'nt find environment variable "{CommandLineArgKey}" ...""";
        }        
    }
}