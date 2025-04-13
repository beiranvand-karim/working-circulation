namespace cross_application_feature_development_management.Names
{
    public class PrimaryApplication
    {
        public string GetName()
        {
            const string primaryApplicationNameKey = "--primary-application-name";
            var name = CommandLineArgs.GetByKey(primaryApplicationNameKey);
            return name;
        }
    }
}