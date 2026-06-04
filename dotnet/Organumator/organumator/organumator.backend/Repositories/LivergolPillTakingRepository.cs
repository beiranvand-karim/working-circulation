using organumator.Data;
using organumator.Dtos;
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

        public async Task<PagedResult<LivergolPillTakingModel>> GetAllLivergolPillTakingsPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await applicationDbContext.LivergolPillTakings.CountAsync();
            var items = await applicationDbContext.LivergolPillTakings
                .OrderByDescending(x => x.PerformedOnDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<LivergolPillTakingModel>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<LivergolPillTakingModel> GetLivergolPillTakingByIdAsync(int id)
        {
            var livergolPillTaking = await applicationDbContext.LivergolPillTakings.FirstOrDefaultAsync(x => x.Id == id);
            return livergolPillTaking switch
            {
                null => throw new Exception($"LivergolPillTaking with id {id} not found."),
                _ => livergolPillTaking
            };
        }

        public async Task<LivergolPillTakingModel> UpdateLivergolPillTakingAsync(LivergolPillTakingModel livergolPillTaking)
        {
            applicationDbContext.LivergolPillTakings.Update(livergolPillTaking);
            await applicationDbContext.SaveChangesAsync();
            return livergolPillTaking;
        }
    }
}