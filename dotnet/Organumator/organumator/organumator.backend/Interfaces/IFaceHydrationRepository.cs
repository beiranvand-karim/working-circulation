using organumator.Dtos;
using organumator.Models;

namespace organumator.Interfaces
{
    public interface IFaceHydrationRepository
    {
        Task<FaceHydration> AddFaceHydrationAsync(FaceHydration faceHydration);
        Task<PagedResult<FaceHydration>> GetAllFaceHydrationsPagedAsync(int pageNumber, int pageSize);
        Task<FaceHydration> GetFaceHydrationByIdAsync(int id);
        Task<FaceHydration> UpdateFaceHydrationAsync(FaceHydration faceHydration);
        Task DeleteFaceHydrationAsync(int id);
    }
}

