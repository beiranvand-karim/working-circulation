namespace cafdemalihapa.Applications
{
    public static class Applications
    {
        public static string Get()
        {
            var application = CommandLineArgs.GetByKey("--application");
            return application;
        }

        public static bool IsCafdemalihapa(this string application)
        {
            return application == "cafdemalihapa";
        }

        public static bool IsNotepadPlusPlusFileManagementApplication(this string application)
        {
            return application == "notepad-plus-plus-file-management";
        }

        public static bool IsIdeManagementApplication(this string application)
        {
            return application == "ide-management";
        }

        public static bool IsDirectoryManagementApplication(this string application)
        {
            return application == "directory-management";
        }
    }
}
