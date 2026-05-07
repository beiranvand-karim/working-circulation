namespace cross_application_feature_development_management.Applications.Cafdem
{
    public class CodeBase
    {
        public string GetCodeBaseValue()
        {
            var codeBase = CommandLineArgs.GetByKey("--code-base");
            return codeBase;
        }
    }
}