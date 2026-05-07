using organumator.Models;

namespace organumator.Interfaces
{
    public interface ILivergolPillTakingRepository
    {
        Task<LivergolPillTakingModel> AddLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking);
        Task<List<LivergolPillTakingModel>> GetAllLivergolPillTakingsAsync();
        Task<LivergolPillTakingModel> GetLivergolPillTakingByIdAsync(int id);
        Task<LivergolPillTakingModel> UpdateLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking);
        Task DeleteLivergolPillTakingAsync(int id);

    }
}