using Microsoft.EntityFrameworkCore;
using organumator.Data;
using organumator.Interfaces;

namespace organumator.Repositories
{
    public class AroundBrushingRepository(ApplicationDbContext _context) : IAroundBrushingRepository
    {

        public async Task<Models.AroundBrushing> AddAroundBrushingAsync(Models.AroundBrushing aroundBrushing)
        {
            _context.AroundBrushings.Add(aroundBrushing);
            await _context.SaveChangesAsync();
            return aroundBrushing;
        }

        public async Task<List<Models.AroundBrushing>> GetAllAroundBrushingsAsync()
        {
            return await _context.AroundBrushings.ToListAsync();
        }

        public async Task<Models.AroundBrushing> GetAroundBrushingByIdAsync(int id)
        {
            var aroundBrushing = await _context.AroundBrushings.FirstOrDefaultAsync(x => x.Id == id);
            return aroundBrushing switch
            {
                null => throw new Exception($"AroundBrushing with id {id} not found."),
                _ => aroundBrushing
            };
        }

        public async Task<Models.AroundBrushing> UpdateAroundBrushingAsync(Models.AroundBrushing aroundBrushing)
        {
            var existingAroundBrushing = await _context.AroundBrushings.FirstOrDefaultAsync(x => x.Id == aroundBrushing.Id);
            if (existingAroundBrushing == null)
            {
                throw new Exception($"AroundBrushing with id {aroundBrushing.Id} not found.");
            }
            existingAroundBrushing.PerformedOnDate = aroundBrushing.PerformedOnDate;
            await _context.SaveChangesAsync();
            return existingAroundBrushing;
        }

        public async Task DeleteAroundBrushingAsync(int id)
        {
            var aroundBrushing = await _context.AroundBrushings.FirstOrDefaultAsync(x => x.Id == id);
            if (aroundBrushing == null)
            {
                throw new Exception($"AroundBrushing with id {id} not found.");
            }
            _context.AroundBrushings.Remove(aroundBrushing);
            await _context.SaveChangesAsync();
        }
    }
}