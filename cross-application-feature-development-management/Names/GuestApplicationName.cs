namespace cross_application_feature_development_management.Names
{
    public class GuestApplicationName(CommandLineArgs commandLineArgs)
    {
        public string GetName()
        {
            const string guestApplicationNameKey = "--guest-application-name";
            var name = commandLineArgs.GetByKey(guestApplicationNameKey);
            return name;
        }
    }
}