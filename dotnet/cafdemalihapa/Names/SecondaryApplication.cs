namespace cafdemalihapa.Names
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