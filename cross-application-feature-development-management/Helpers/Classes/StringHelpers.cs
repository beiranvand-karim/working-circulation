using cross_application_feature_development_management.Helpers.Interfaces;

namespace cross_application_feature_development_management.Helpers.Classes
{
    public class StringHelpers : IStringHelpers
    {
        public string WrappInQoutationMarks(string value)
        {
            string valueToWrite = string.Format("\"{0}\"", value);
            return valueToWrite;
        }
        public string StripQoutationMarks(string value)
        {
            string valueToWrite = value.Replace("\"", "");
            return valueToWrite;
        }
    }
}