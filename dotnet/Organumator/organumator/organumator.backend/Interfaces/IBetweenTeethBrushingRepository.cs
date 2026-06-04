using organumator.Dtos;
using organumator.Models;

namespace organumator.Interfaces
{
    public interface IBetweenTeethBrushingRepository
    {
        Task<PagedResult<BetweenTeethBrushing>> GetAllBetweenTeethBrushingPagedAsync(int pageNumber, int pageSize);
        Task<BetweenTeethBrushing> GetBetweenTeethBrushingByIdAsync(int id);
        Task<BetweenTeethBrushing> AddBetweenTeethBrushingAsync(BetweenTeethBrushing betweenTeethBrushing);
        Task UpdateBetweenTeethBrushingAsync(BetweenTeethBrushing betweenTeethBrushing);
        Task DeleteBetweenTeethBrushingAsync(int id);
    }
}