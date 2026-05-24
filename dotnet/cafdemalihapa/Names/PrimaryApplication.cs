namespace cafdemalihapa.Names
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