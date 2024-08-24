using notepad_plus_plus_file_management.Combiners.Interfaces;
using notepad_plus_plus_file_management.Interfaces;

namespace notepad_plus_plus_file_management.Combiners.Classes
{
    public class DirectoriesNameToKeyMap(ICommandLineArgs commandLineArgs) : IDirectoriesNameToKeyMap
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetValue(string key)
        {
            string groupKey = "DirectoriesNameToKeyMap";
            return commandLineArgs.GetKey2(groupKey, key);
        }
    }
}