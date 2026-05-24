namespace cafdemalihapa.Applications.Cafdemalihapa
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