using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Names.Classses
{
    public interface IFeatureName
    {
        public string GetName();
    }

    public class FeatureName(ICommandLineArgs commandLineArgs) : IFeatureName
    {
        private readonly ICommandLineArgs commandLineArgs = commandLineArgs;
        public string GetName()
        {
            const string guestApplicationNameKey = "--feature-name";
            var name = commandLineArgs.GetByKey(guestApplicationNameKey);
            return name;
        }
    }
}