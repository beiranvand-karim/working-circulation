using Microsoft.EntityFrameworkCore;
using organumator.Data;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Repositories
{
    public class FaceHydrationRepository(ApplicationDbContext applicationDbContext) : IFaceHydrationRepository
    {
        public async Task<FaceHydration> AddFaceHydrationAsync(FaceHydration faceHydration)
        {
            applicationDbContext.FaceHydrations.Add(faceHydration);
            await applicationDbContext.SaveChangesAsync();
            return faceHydration;
        }

        public async Task DeleteFaceHydrationAsync(int id)
        {
            var faceHydration = await applicationDbContext.FaceHydrations.FirstOrDefaultAsync(x => x.Id == id);
            if (faceHydration == null)
            {
                throw new Exception($"FaceHydration with id {id} not found.");
            }
            applicationDbContext.FaceHydrations.Remove(faceHydration);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<FaceHydration>> GetAllFaceHydrationsAsync()
        {
            return await applicationDbContext.FaceHydrations
                .OrderByDescending(x => x.PerformedOnDate)
                .ToListAsync();
        }

        public async Task<FaceHydration> GetFaceHydrationByIdAsync(int id)
        {
            var faceHydration = await applicationDbContext.FaceHydrations.FirstOrDefaultAsync(x => x.Id == id);
            return faceHydration switch
            {
                null => throw new Exception($"FaceHydration with id {id} not found."),
                _ => faceHydration
            };
        }
        
        public async Task<FaceHydration> UpdateFaceHydrationAsync(FaceHydration faceHydration)
        {
            var existingFaceHydration = await applicationDbContext.FaceHydrations.FirstOrDefaultAsync(x => x.Id == faceHydration.Id);
            if (existingFaceHydration == null)
            {
                throw new Exception($"FaceHydration with id {faceHydration.Id} not found.");
            }
            existingFaceHydration.PerformedOnDate = faceHydration.PerformedOnDate;
            await applicationDbContext.SaveChangesAsync();
            return existingFaceHydration;
        }
    }
}