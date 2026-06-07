namespace cafdemalihapa.Applications.DirectoryManagement
{
    public class DirectoryManagement
    (
        Creation creation,
        Opening opening,
        Shutting shutting
    )
    {
        public void Run()
        {
            if (!Applications.Get().IsDirectoryManagementApplication())
            {
                return;
            }
            opening.OpenDirectoryToBeOpen();
            creation.Create();
            opening.Open();
            shutting.Shut();
        }
    }
}