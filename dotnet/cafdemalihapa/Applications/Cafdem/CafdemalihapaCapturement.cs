namespace cafdemalihapa.Applications.Cafdem
{
    public class CafdemalihapaCapturement
    {
        public string GetFormat()
        {
            var format = CommandLineArgs.GetByKey("--format");
            return format;
        }

        public bool IsFormatJson()
        {
            return GetFormat() == "json";
        }

        private string GetFilement()
        {
            var format = CommandLineArgs.GetByKey("--filement");
            return format;
        }

        public bool IsFilementSplit()
        {
            return GetFilement() == "split";
        }

        public bool IsFilementUnite()
        {
            return GetFilement() == "unite";
        }
    }
}

