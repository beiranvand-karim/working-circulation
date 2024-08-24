using notepad_plus_plus_file_management.Helpers.Interfaces;

namespace notepad_plus_plus_file_management.Helpers.Classes
{
    public class StringHelpers : IStringHelpers
    {
        public string WrappInQoutationMarks(string value)
        {
            string valueToWrite = string.Format("\"{0}\"", value);
            return valueToWrite;
        }
    }
}