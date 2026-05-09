using Microsoft.EntityFrameworkCore;
using organumator.Data;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Repositories
{
    public class BetweenTeethBrushingRepository(ApplicationDbContext applicationDbContext) : IBetweenTeethBrushingRepository
    {

        public async Task<BetweenTeethBrushing> AddBetweenTeethBrushingAsync(BetweenTeethBrushing betweenTeethBrushing)
        {
            applicationDbContext.BetweenTeethBrushings.Add(betweenTeethBrushing);
            await applicationDbContext.SaveChangesAsync();
            return betweenTeethBrushing;
        }

        public async Task DeleteBetweenTeethBrushingAsync(int id)
        {
            var betweenTeethBrushing = await applicationDbContext.BetweenTeethBrushings.FindAsync(id);
            if (betweenTeethBrushing != null)
            {
                applicationDbContext.BetweenTeethBrushings.Remove(betweenTeethBrushing);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BetweenTeethBrushing>> GetAllBetweenTeethBrushingAsync()
        {
            return await applicationDbContext.BetweenTeethBrushings.ToListAsync();
        }

        public async Task<BetweenTeethBrushing> GetBetweenTeethBrushingByIdAsync(int id)
        {
            var betweenTeethBrushing = await applicationDbContext.BetweenTeethBrushings.FindAsync(id);
            return betweenTeethBrushing switch
            {
                null => throw new Exception($"BetweenTeethBrushing with id {id} not found."),
                _ => betweenTeethBrushing
            };
        }

        public async Task UpdateBetweenTeethBrushingAsync(BetweenTeethBrushing betweenTeethBrushing)
        {
            applicationDbContext.Entry(betweenTeethBrushing).State = EntityState.Modified;
            await applicationDbContext.SaveChangesAsync();
        }
    }
}