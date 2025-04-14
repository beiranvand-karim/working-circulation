namespace cross_application_feature_development_management.Names
{
    public class GuestApplicationName
    {
        public string GetName()
        {
            const string guestApplicationNameKey = "--guest-application-name";
            var name = CommandLineArgs.GetByKey(guestApplicationNameKey);
            return name;
        }
    }
}