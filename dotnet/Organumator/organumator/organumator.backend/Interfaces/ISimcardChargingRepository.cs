using organumator.Models;

namespace organumator.Interfaces
{
    public interface ISimcardChargingRepository
    {
        Task<SimcardCharging> SaveAsync(DateTime chargedAt);
        Task<List<SimcardCharging>> GetAllAsync();
        Task<SimcardCharging> GetByIdAsync(int id);
Task DeleteAsync(int id);
    }
}
