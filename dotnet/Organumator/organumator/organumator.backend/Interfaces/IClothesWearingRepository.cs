using organumator.Models;

namespace organumator.Interfaces
{
    public interface IClothesWearingRepository
    {
        Task<ClothesWearing> AddClothesWearingAsync(ClothesWearing clothesWearing);
        Task<List<ClothesWearing>> GetAllClothesWearingsAsync();
        Task<ClothesWearing> GetClothesWearingByIdAsync(int id);
        Task<ClothesWearing> UpdateClothesWearingAsync(ClothesWearing clothesWearing);
        Task DeleteClothesWearingAsync(int id);
    }
}
