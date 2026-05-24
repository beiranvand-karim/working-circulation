using cafdemalihapa.Applications.Cafdem;

namespace cafdemalihapa.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.CodeBases
{
    public class CodeBaseDirectory(
        SeparationFilementDirectory separationFilementDirectory,
        CodeBase codeBase
    )
    {
        public string GetPath()
        {
            var codeBaseValue = codeBase.GetCodeBaseValue();
            return Path.Combine(separationFilementDirectory.GetPath(), codeBaseValue);
        }
    }
}