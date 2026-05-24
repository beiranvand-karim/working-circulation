namespace cafdemalihapa.Applications.NotepadPlusPlusFileManagement
{
    public class ProcessInformationGroup
    {
        public List<ProcessInformation>? Group { get; set; } = [];

        public void Add(ProcessInformation processInformation)
        {
            Group?.Add(processInformation);
        }
        public void AddInFront(ProcessInformation processInformation)
        {
            Group?.Insert(0, processInformation);
        }
    }
}