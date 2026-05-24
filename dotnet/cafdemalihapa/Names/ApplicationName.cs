namespace cafdemalihapa.Names
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
