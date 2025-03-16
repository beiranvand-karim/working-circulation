namespace cross_application_feature_development_management
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