using organumator.Dtos;
using organumator.Models;

namespace organumator.Interfaces
{
    public interface ILivergolPillTakingRepository
    {
        Task<LivergolPillTakingModel> AddLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking);
        Task<PagedResult<LivergolPillTakingModel>> GetAllLivergolPillTakingsPagedAsync(int pageNumber, int pageSize);
        Task<LivergolPillTakingModel> GetLivergolPillTakingByIdAsync(int id);
        Task<LivergolPillTakingModel> UpdateLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking);
        Task DeleteLivergolPillTakingAsync(int id);
    }
}