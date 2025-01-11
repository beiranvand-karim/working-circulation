using cross_application_feature_development_management.Interfaces;
using cross_application_feature_development_management.Names.Interfaces;

namespace cross_application_feature_development_management.Names.Classses
{
    public class GuestApplicationName(ICommandLineArgs commandLineArgs) : IGuestApplicationName
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;

        public string GetName()
        {
            const string guestApplicationNameKey = "--guest-application-name";
            var name = commandLineArgs.GetByKey(guestApplicationNameKey);
            return name;
        }
    }
}