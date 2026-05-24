namespace cafdemalihapa.Applications.Cafdem
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