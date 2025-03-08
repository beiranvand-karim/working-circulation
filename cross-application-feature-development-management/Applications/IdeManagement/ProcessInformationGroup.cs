namespace cross_application_feature_development_management.Applications.IdeManagement
{
    public class IdeProcessInformationGroup
    {
        public List<IdeProcessInformation>? Group { get; set; } = [];

        public void Add(IdeProcessInformation ideProcessInformation)
        {
            Group?.Add(ideProcessInformation);
        }
        public void AddInFront(IdeProcessInformation ideProcessInformation)
        {
            Group?.Insert(0, ideProcessInformation);
        }
    }
}