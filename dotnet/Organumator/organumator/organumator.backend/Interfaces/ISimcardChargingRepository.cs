using organumator.Dtos;
using organumator.Models;

namespace organumator.Interfaces
{
    public interface ISimcardChargingRepository
    {
        Task<SimcardCharging> SaveAsync(DateTime chargedAt);
        Task<PagedResult<SimcardCharging>> GetAllPagedAsync(int pageNumber, int pageSize);
        Task<SimcardCharging> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
