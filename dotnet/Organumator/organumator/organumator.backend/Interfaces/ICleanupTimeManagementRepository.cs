using organumator.Models;

namespace organumator.Interfaces
{
    public interface ICleanupTimeManagementRepository
    {
        Task<CleanupTimeManagement> SaveStartAsync(DateTime startedAt);
        Task<CleanupTimeManagement> SaveFinishAsync(int id, DateTime finishedAt);
        Task<List<CleanupTimeManagement>> GetAllAsync();
        Task<CleanupTimeManagement> GetByIdAsync(int id);
        Task<List<(DateOnly Date, int Count, long TotalDurationSeconds)>> GetDaysWithDataAsync();
        Task<List<CleanupTimeManagement>> GetByDayAsync(DateOnly date);
        Task DeleteAsync(int id);
        Task DeleteByDayAsync(DateOnly date);
    }
}
