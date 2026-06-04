using organumator.Data;
using organumator.Dtos;
using organumator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace organumator.Repositories
{
    public class CalciferolTakingRepository(ApplicationDbContext applicationDbContext): ICalciferolTakingRepository
    {

        public async Task<PagedResult<Models.CalciferolTakingModel>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await applicationDbContext.CalciferolTakings.CountAsync();
            var items = await applicationDbContext.CalciferolTakings
                .OrderByDescending(x => x.PerformedOnDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Models.CalciferolTakingModel>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Models.CalciferolTakingModel> GetByIdAsync(int id)
        {
            var entity = await applicationDbContext.CalciferolTakings.FindAsync(id);
            return entity switch
            {
                null => throw new KeyNotFoundException($"CalciferolTaking with ID {id} not found."),
                _ => entity
            };
        }

        public async Task AddAsync(Models.CalciferolTakingModel calciferolTakingModel)
        {
            await applicationDbContext.CalciferolTakings.AddAsync(calciferolTakingModel);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Models.CalciferolTakingModel calciferolTakingModel)
        {
            applicationDbContext.CalciferolTakings.Update(calciferolTakingModel);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await applicationDbContext.CalciferolTakings.FindAsync(id);
            if (entity != null)
            {
                applicationDbContext.CalciferolTakings.Remove(entity);
                await applicationDbContext.SaveChangesAsync();
            }
        }   
    }
}