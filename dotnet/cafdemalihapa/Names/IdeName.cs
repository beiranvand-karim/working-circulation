namespace cafdemalihapa.Names
{
    public class IdeName
    {
        public string GetName()
        {
            const string ideNameKey = "--ide-name";
            var name = CommandLineArgs.GetByKey(ideNameKey);
            return name;
        }
    }
}