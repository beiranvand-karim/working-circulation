namespace notepad_plus_plus_file_management
{
    public class ProccessInformationGroup : IProccessInformationGroup
    {
        public List<ProccessInformation>? Group { get; set; }
        public void Add(ProccessInformation proccessInformation)
        {
            Group = [];
        }

    }

    public interface IProccessInformationGroup
    {
        public void Add(ProccessInformation proccessInformation);
    }
}