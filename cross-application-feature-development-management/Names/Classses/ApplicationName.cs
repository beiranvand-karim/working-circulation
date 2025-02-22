using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Names.Classses
{
    public class ApplicationName(
        ICommandLineArgs commandLineArgs
    ): IApplicationName
    {
        public string GetName()
        {
            const string applicationNameKey = "--application-name";
            var name = commandLineArgs.GetByKey(applicationNameKey);
            return name;
        }
    }

    public  interface IApplicationName
    {
        public string GetName();
    }
}
