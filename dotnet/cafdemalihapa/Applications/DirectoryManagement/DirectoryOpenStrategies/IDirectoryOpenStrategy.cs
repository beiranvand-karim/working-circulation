namespace cafdemalihapa.Applications.DirectoryManagement.DirectoryOpenStrategies
{
    public interface IDirectoryOpenStrategy
    {
        bool CanHandle();

        void Open(string path);
    }
}
