namespace cross_application_feature_development_management.Names
{
    public class SecondaryApplication
    {
        public string GetName()
        {
            const string secondaryApplicationNameKey = "--secondary-application-name";
            var name = CommandLineArgs.GetByKey(secondaryApplicationNameKey);
            return name;
        }
    }
}