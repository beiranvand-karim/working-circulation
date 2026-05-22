using organumator.Models;

namespace organumator.Interfaces
{
    public interface IVacuumCleaningsRepository
    {
        Task<VacuumCleanings> AddVacuumCleaningsAsync(VacuumCleanings vacuumCleanings);
        Task<List<VacuumCleanings>> GetAllVacuumCleaningsAsync();
        Task<VacuumCleanings> GetVacuumCleaningsByIdAsync(int id);
        Task<VacuumCleanings> UpdateVacuumCleaningsAsync(VacuumCleanings vacuumCleanings);
        Task DeleteVacuumCleaningsAsync(int id);
    }
}