namespace cross_application_feature_development_management.Helpers
{
    public class StringHelpers
    {
        public string WrapInQuotationMarks(string value)
        {
            var valueToWrite = $"\"{value}\"";
            return valueToWrite;
        }
        public string StripQuotationMarks(string value)
        {
            var valueToWrite = value.Replace("\"", "");
            return valueToWrite;
        }
    }
}