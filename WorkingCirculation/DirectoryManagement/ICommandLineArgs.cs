namespace DirectoryManagement
{
    public interface ICommandLineArgs
    {
        public string GetKey(string key);
        public string GetKey2(string groupKey, string key);
        public string GetByKey(string CommandLineArgKey);
    }
}