namespace cross_application_feature_development_management.Names
{
    public class HostApplicationName(CommandLineArgs commandLineArgs)
    {
        public string GetName()
        {
            const string hostApplicationNameKey = "--host-application-name";
            var name = commandLineArgs.GetByKey(hostApplicationNameKey);
            return name;
        }
    }
}