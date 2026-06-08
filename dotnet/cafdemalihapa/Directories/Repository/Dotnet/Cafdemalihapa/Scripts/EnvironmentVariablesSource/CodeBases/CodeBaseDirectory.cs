using cafdemalihapa.Applications.Cafdemalihapa;

namespace cafdemalihapa.Directories.Repository.Dotnet.Cafdemalihapa.Scripts.EnvironmentVariablesSource.CodeBases
{
    public class CodeBaseDirectory(
        EnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory,
        CodeBase codeBase
    )
    {
        public string GetPath()
        {
            var codeBaseValue = codeBase.GetCodeBaseValue();
            return Path.Combine(environmentVariablesSourceDirectory.GetPath(), codeBaseValue);
        }
    }
}