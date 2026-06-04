using organumator.Dtos;
using organumator.Models;

namespace organumator.Interfaces
{
    public interface IClothesWearingRepository
    {
        Task<ClothesWearing> AddClothesWearingAsync(ClothesWearing clothesWearing);
        Task<PagedResult<ClothesWearing>> GetAllClothesWearingsPagedAsync(int pageNumber, int pageSize);
        Task<ClothesWearing> GetClothesWearingByIdAsync(int id);
        Task<ClothesWearing> UpdateClothesWearingAsync(ClothesWearing clothesWearing);
        Task DeleteClothesWearingAsync(int id);
    }
}
