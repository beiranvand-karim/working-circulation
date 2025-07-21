using cross_application_feature_development_management.Applications.Cafdem;
using cross_application_feature_development_management.Names;

namespace cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.Files.Jsons
{
    public class MutantVariablesFile(
            SeparationFilementDirectory separationFilementDirectory,
            PrimaryApplication primaryApplication,
            SecondaryApplication secondaryApplication,
            CafdemTerminalCapturement cafdemTerminalCapturement
        )
    {
        public string GetName()
        {
            var primaryApplicationName = primaryApplication.GetName();
            var secondaryApplicationName = secondaryApplication.GetName();
            var format = cafdemTerminalCapturement.GetFormat();
            var fileName = $"{primaryApplicationName}-{secondaryApplicationName}.{format}";
            return fileName;
        }

        public string GetPath()
        {
            var name =GetName();
            return Path.Combine(separationFilementDirectory.GetPath(), name);
        }
    }
}