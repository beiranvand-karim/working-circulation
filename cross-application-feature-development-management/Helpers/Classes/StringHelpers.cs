using cross_application_feature_development_management.Helpers.Interfaces;

namespace cross_application_feature_development_management.Helpers.Classes
{
    public class StringHelpers : IStringHelpers
    {
        public string WrappInQoutationMarks(string value)
        {
            var valueToWrite = $"\"{value}\"";
            return valueToWrite;
        }
        public string StripQoutationMarks(string value)
        {
            var valueToWrite = value.Replace("\"", "");
            return valueToWrite;
        }
    }
}