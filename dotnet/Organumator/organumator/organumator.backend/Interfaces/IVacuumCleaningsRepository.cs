using organumator.Dtos;
using organumator.Models;

namespace organumator.Interfaces
{
    public interface IVacuumCleaningsRepository
    {
        Task<VacuumCleanings> AddVacuumCleaningsAsync(VacuumCleanings vacuumCleanings);
        Task<PagedResult<VacuumCleanings>> GetAllVacuumCleaningsPagedAsync(int pageNumber, int pageSize);
        Task<VacuumCleanings> GetVacuumCleaningsByIdAsync(int id);
        Task<VacuumCleanings> UpdateVacuumCleaningsAsync(VacuumCleanings vacuumCleanings);
        Task DeleteVacuumCleaningsAsync(int id);
    }
}