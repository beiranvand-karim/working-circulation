namespace cross_application_feature_development_management.Names
{
    public class FeatureName(CommandLineArgs commandLineArgs)
    {
        public string GetName()
        {
            const string featureNameKey = "--feature-name";
            var name = CommandLineArgs.GetByKey(featureNameKey);
            return name;
        }
    }
}