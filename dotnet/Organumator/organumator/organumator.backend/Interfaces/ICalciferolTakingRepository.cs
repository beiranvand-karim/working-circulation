using organumator.Dtos;

namespace organumator.Interfaces
{
    public interface ICalciferolTakingRepository
    {
        Task<PagedResult<Models.CalciferolTakingModel>> GetAllPagedAsync(int pageNumber, int pageSize);
        Task<Models.CalciferolTakingModel> GetByIdAsync(int id);
        Task AddAsync(Models.CalciferolTakingModel calciferolTakingModel);
        Task UpdateAsync(Models.CalciferolTakingModel calciferolTakingModel);
        Task DeleteAsync(int id);
    }
}