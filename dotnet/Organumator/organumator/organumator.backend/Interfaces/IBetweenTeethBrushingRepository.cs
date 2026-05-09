using organumator.Models;

namespace organumator.Interfaces
{
    public interface IBetweenTeethBrushingRepository
    {
        Task<IEnumerable<BetweenTeethBrushing>> GetAllBetweenTeethBrushingAsync();
        Task<BetweenTeethBrushing> GetBetweenTeethBrushingByIdAsync(int id);
        Task<BetweenTeethBrushing> AddBetweenTeethBrushingAsync(BetweenTeethBrushing betweenTeethBrushing);
        Task UpdateBetweenTeethBrushingAsync(BetweenTeethBrushing betweenTeethBrushing);
        Task DeleteBetweenTeethBrushingAsync(int id);

    }
}