using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organumator.Interfaces
{
    public interface IAroundBrushingRepository
    {
        Task<Models.AroundBrushing> AddAroundBrushingAsync(Models.AroundBrushing aroundBrushing);
        Task<List<Models.AroundBrushing>> GetAllAroundBrushingsAsync();
        Task<Models.AroundBrushing> GetAroundBrushingByIdAsync(int id);
        Task<Models.AroundBrushing> UpdateAroundBrushingAsync(Models.AroundBrushing aroundBrushing);
        Task DeleteAroundBrushingAsync(int id);
    }
}