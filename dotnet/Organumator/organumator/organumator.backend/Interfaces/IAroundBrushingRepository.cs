using organumator.Dtos;

namespace organumator.Interfaces
{
    public interface IAroundBrushingRepository
    {
        Task<Models.AroundBrushing> AddAroundBrushingAsync(Models.AroundBrushing aroundBrushing);
        Task<PagedResult<Models.AroundBrushing>> GetAllAroundBrushingsPagedAsync(int pageNumber, int pageSize);
        Task<Models.AroundBrushing> GetAroundBrushingByIdAsync(int id);
        Task<Models.AroundBrushing> UpdateAroundBrushingAsync(Models.AroundBrushing aroundBrushing);
        Task DeleteAroundBrushingAsync(int id);
    }
}
