namespace cross_application_feature_development_management
{
    public class ProcessInformationGroup : IProcessInformationGroup
    {
        public List<ProcessInformation>? group { get; set; } = [];

        public void Add(ProcessInformation processInformation)
        {
            group?.Add(processInformation);
        }
        public void AddInFront(ProcessInformation processInformation)
        {
            group?.Insert(0, processInformation);
        }

    }

    public interface IProcessInformationGroup
    {
        public void Add(ProcessInformation processInformation);
        public void AddInFront(ProcessInformation processInformation);
    }
}