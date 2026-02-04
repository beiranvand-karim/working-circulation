using cross_application_feature_development_management.Applications.Cafdem;

namespace cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource.SeparationFilement.CodeBases
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