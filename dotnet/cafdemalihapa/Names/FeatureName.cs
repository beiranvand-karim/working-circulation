namespace cafdemalihapa.Names
{
    public class FeatureName
    {
        public string GetName()
        {
            const string featureNameKey = "--feature-name";
            var name = CommandLineArgs.GetByKey(featureNameKey);
            return name;
        }
    }
}