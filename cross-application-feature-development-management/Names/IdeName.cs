namespace cross_application_feature_development_management.Names
{
    public class IdeName(
        CommandLineArgs commandLineArgs
    )
    {
        public string GetName()
        {
            const string ideNameKey = "--ide-name";
            var name = CommandLineArgs.GetByKey(ideNameKey);
            return name;
        }
    }
}