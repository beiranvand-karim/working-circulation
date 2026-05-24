using cafdemalihapa.Applications.Cafdem;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.CodeBases;
using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.Files.Jsons
{
    public class MutantVariablesFile(
            PrimaryApplication primaryApplication,
            SecondaryApplication secondaryApplication,
            CafdemalihapaCapturement cafdemTerminalCapturement,
            CodeBaseDirectory codeBaseDirectory
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
            return Path.Combine(
                codeBaseDirectory.GetPath(), name);
        }
    }
}