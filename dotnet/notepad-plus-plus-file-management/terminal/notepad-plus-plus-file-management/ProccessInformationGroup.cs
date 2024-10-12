namespace notepad_plus_plus_file_management
{
    public class ProccessInformationGroup : IProccessInformationGroup
    {
        public ProccessInformationGroup()
        {
            Group = [];
        }

        public List<ProccessInformation>? Group { get; set; }
        public void Add(ProccessInformation proccessInformation)
        {
            Group?.Add(proccessInformation);
        }
        public void AddInFront(ProccessInformation proccessInformation)
        {
            Group?.Insert(0, proccessInformation);
        }

    }

    public interface IProccessInformationGroup
    {
        public void Add(ProccessInformation proccessInformation);
        public void AddInFront(ProccessInformation proccessInformation);
    }
}