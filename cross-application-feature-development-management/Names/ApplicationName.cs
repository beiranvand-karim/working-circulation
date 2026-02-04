namespace cross_application_feature_development_management.Names
{
    public class ApplicationName
    {
        public string GetName()
        {
            const string applicationNameKey = "--application-name";
            var name = CommandLineArgs.GetByKey(applicationNameKey);
            return name;
        }
    }
}
