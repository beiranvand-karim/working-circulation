namespace cafdemalihapa.Applications
{
    public static class Commands
    {
        public static string Get()
        {
            var command = CommandLineArgs.GetByKey("--command");
            return command;
        }

        public static bool IsCreate(this string command)
        {
            return command == "create";
        }

        public static bool IsOpen(this string command)
        {
            return command == "open";
        }

        public static bool IsShut(this string command)
        {
            return command == "shut";
        }

        public static bool IsDirectoryToBeOpen(this string command)
        {
            return command == "directory-to-be-open";
        }
    }
}
