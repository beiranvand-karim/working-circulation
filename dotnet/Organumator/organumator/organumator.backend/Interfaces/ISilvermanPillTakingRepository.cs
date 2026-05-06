using organumator.Models;

namespace organumator.Interfaces
{
    public interface ISilvermanPillTakingRepository
    {
        Task<SilvermanPillTaking> AddSilvermanPillTakingAsync(SilvermanPillTaking silvermanPillTaking);
        Task<List<SilvermanPillTaking>> GetAllSilvermanPillTakingsAsync();
        Task<SilvermanPillTaking> GetSilvermanPillTakingByIdAsync(int id);
        Task<SilvermanPillTaking> UpdateSilvermanPillTakingAsync(SilvermanPillTaking silvermanPillTaking);
        Task DeleteSilvermanPillTakingAsync(int id);
    }
}