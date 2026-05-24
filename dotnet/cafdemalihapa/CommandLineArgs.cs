namespace cafdemalihapa
{
    public class CommandLineArgs
    {
        public static string GetByKey(string commandLineArgKey)
        {
            var commandLineArgs = Environment.GetCommandLineArgs();

            var index = Array.FindIndex(commandLineArgs, x => x.StartsWith(commandLineArgKey));
            if (index == -1) return $"""couldn't find environment variable "{commandLineArgKey}" ...""";
            var commandLineArgValue = commandLineArgs[index + 1];
            return commandLineArgValue;
        }
    }
}