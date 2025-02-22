using cross_application_feature_development_management.Interfaces;

namespace cross_application_feature_development_management.Names.Classses
{
    public class IdeName(
        ICommandLineArgs commandLineArgs
    ): IIdeName
    {
        public string GetName()
        {
            const string ideNameKey = "--ide-name";
            var name = commandLineArgs.GetByKey(ideNameKey);
            return name;
        }
    }

    public interface IIdeName
    {
        public string GetName();
    }
}