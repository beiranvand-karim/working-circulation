namespace cross_application_feature_development_management.Names
{
    public class PrimaryApplicationName(
        CommandLineArgs commandLineArgs
    )
    {
        public string GetName()
        {
            const string primaryApplicationNameKey = "--primary-application-name";
            var name = commandLineArgs.GetByKey(primaryApplicationNameKey);
            return name;
        }
    }
}