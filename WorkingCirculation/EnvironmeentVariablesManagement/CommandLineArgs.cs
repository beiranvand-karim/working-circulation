
namespace EnvironmentVariablesManagement
{
    internal class CommandLineArgs 
    {
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