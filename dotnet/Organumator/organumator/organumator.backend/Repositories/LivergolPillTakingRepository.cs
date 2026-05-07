using organumator.Data;
using organumator.Interfaces;
using organumator.Models;
using Microsoft.EntityFrameworkCore;

namespace organumator.Repositories
{
    public class LivergolPillTakingRepository(ApplicationDbContext applicationDbContext) : ILivergolPillTakingRepository
    {
        public async Task<LivergolPillTakingModel> AddLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking)
        {
            applicationDbContext.LivergolPillTakings.Add(livergolPillTaking);
            await applicationDbContext.SaveChangesAsync();
            return livergolPillTaking;
        }

        public async Task DeleteLivergolPillTakingAsync(int id)
        {
            var livergolPillTaking = await applicationDbContext.LivergolPillTakings.FirstOrDefaultAsync(x => x.Id == id);
            if (livergolPillTaking == null)
            {
                throw new Exception($"LivergolPillTaking with id {id} not found.");
            }
            applicationDbContext.LivergolPillTakings.Remove(livergolPillTaking);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<LivergolPillTakingModel>> GetAllLivergolPillTakingsAsync()
        {
            return await applicationDbContext.LivergolPillTakings.ToListAsync();
        }

        public async Task<LivergolPillTakingModel> GetLivergolPillTakingByIdAsync(int id)
        {
            var livergolPillTaking = await applicationDbContext.LivergolPillTakings.FirstOrDefaultAsync(x => x.Id == id);
            if (livergolPillTaking == null)
            {
                throw new Exception($"LivergolPillTaking with id {id} not found.");
            }
            return livergolPillTaking;
        }

        public async Task<LivergolPillTakingModel> UpdateLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking)
        {
            applicationDbContext.LivergolPillTakings.Update(livergolPillTaking);
            await applicationDbContext.SaveChangesAsync();
            return livergolPillTaking;
        }
    }
}