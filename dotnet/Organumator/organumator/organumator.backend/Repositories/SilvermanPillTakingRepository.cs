using Microsoft.EntityFrameworkCore;
using organumator.Data;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Repositories
{
    public class SilvermanPillTakingRepository(ApplicationDbContext applicationDbContext) : ISilvermanPillTakingRepository
    {

        public async Task<SilvermanPillTaking> AddSilvermanPillTakingAsync(SilvermanPillTaking silvermanPillTaking)
        {
            applicationDbContext.SilvermanPillTakings.Add(silvermanPillTaking);
            await applicationDbContext.SaveChangesAsync();
            return silvermanPillTaking;
        }

        public async Task<List<SilvermanPillTaking>> GetAllSilvermanPillTakingsAsync()
        {
            return await applicationDbContext.SilvermanPillTakings.ToListAsync();
        }

        public async Task<SilvermanPillTaking> GetSilvermanPillTakingByIdAsync(int id)
        {

            var silvermanPillTaking = await applicationDbContext.SilvermanPillTakings.FindAsync(id);
            return silvermanPillTaking switch
            {
                null => throw new Exception($"SilvermanPillTaking with id {id} not found."),
                _ => silvermanPillTaking
            };
        }

        public async Task<SilvermanPillTaking> UpdateSilvermanPillTakingAsync(SilvermanPillTaking silvermanPillTaking)
        {
            applicationDbContext.SilvermanPillTakings.Update(silvermanPillTaking);
            await applicationDbContext.SaveChangesAsync();
            return silvermanPillTaking;
        }

        public async Task DeleteSilvermanPillTakingAsync(int id)
        {
            var silvermanPillTaking = await applicationDbContext.SilvermanPillTakings.FindAsync(id);
            if (silvermanPillTaking == null)
            {
                throw new Exception($"SilvermanPillTaking with id {id} not found.");
            }
            applicationDbContext.SilvermanPillTakings.Remove(silvermanPillTaking);
            await applicationDbContext.SaveChangesAsync();
        
        }
    }
}