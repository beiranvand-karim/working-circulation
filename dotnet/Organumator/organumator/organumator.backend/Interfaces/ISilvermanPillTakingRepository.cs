using organumator.Dtos;
using organumator.Models;

namespace organumator.Interfaces
{
    public interface ISilvermanPillTakingRepository
    {
        Task<SilvermanPillTaking> AddSilvermanPillTakingAsync(SilvermanPillTaking silvermanPillTaking);
        Task<PagedResult<SilvermanPillTaking>> GetAllSilvermanPillTakingsPagedAsync(int pageNumber, int pageSize);
        Task<SilvermanPillTaking> GetSilvermanPillTakingByIdAsync(int id);
        Task<SilvermanPillTaking> UpdateSilvermanPillTakingAsync(SilvermanPillTaking silvermanPillTaking);
        Task DeleteSilvermanPillTakingAsync(int id);
    }
}