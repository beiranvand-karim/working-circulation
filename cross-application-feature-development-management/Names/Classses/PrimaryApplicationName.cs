using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Names.Classses
{
    public class PrimaryApplicationName(
        ICommandLineArgs commandLineArgs
    )
    {
        public string GetName()
        {
            const string primaryApplicationNameKey = "--primary-application-name";
            var name = commandLineArgs.GetByKey(primaryApplicationNameKey);
            return name;
        }
    }

    public interface IPrimaryApplicationName
    {
        public string GetName();
    }
}