namespace cafdemalihapa.Applications
{
    public static class PathUtility
    {
        public static string NormalizeSlashes(string path, SlashStyle style = SlashStyle.AutoByOS)
        {
            switch (style)
            {
                case SlashStyle.ForceSlash:
                    return path.Replace("\\", "/");
                case SlashStyle.ForceBackslash:
                    return path.Replace("/", "\\");
                case SlashStyle.AutoByOS:
                default:
                    char correctSlash = Path.DirectorySeparatorChar;
                    char wrongSlash = correctSlash == '\\' ? '/' : '\\';
                    return path.Replace(wrongSlash, correctSlash);
            }
        }

        public enum SlashStyle
        {
            AutoByOS,
            ForceSlash,
            ForceBackslash
        }
    }
}