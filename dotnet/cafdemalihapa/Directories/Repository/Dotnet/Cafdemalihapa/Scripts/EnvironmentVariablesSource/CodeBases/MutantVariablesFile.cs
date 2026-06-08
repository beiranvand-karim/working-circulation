using cafdemalihapa.Applications.Cafdemalihapa;
using cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.CodeBases;
using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.Files.Jsons
{
    public class MutantVariablesFile(
            PrimaryApplication primaryApplication,
            SecondaryApplication secondaryApplication,
            CodeBaseDirectory codeBaseDirectory
        )
    {
        public string GetName()
        {
            var primaryApplicationName = primaryApplication.GetName();
            var secondaryApplicationName = secondaryApplication.GetName();
            var fileName = $"{primaryApplicationName}-{secondaryApplicationName}.json";
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