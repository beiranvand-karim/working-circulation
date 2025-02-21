using cross_application_feature_development_management.Applications.IdeManagement;

namespace cross_application_feature_development_management
{
    public class IdeProcessInformationGroup : IIdeProcessInformationGroup
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

    public interface IIdeProcessInformationGroup
    {
        public void Add(IdeProcessInformation ideProcessInformation);
        public void AddInFront(IdeProcessInformation ideProcessInformation);
    }
}