namespace cafdemalihapa.Applications.DirectoryManagement
{
    public class Shutting
    {
        public void Shut()
        {
            if (!Commands.Get().IsShut())
            {
                return;
            }
        }
    }
}
