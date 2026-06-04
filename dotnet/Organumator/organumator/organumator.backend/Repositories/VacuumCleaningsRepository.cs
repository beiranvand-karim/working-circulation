using Microsoft.EntityFrameworkCore;
using organumator.Data;
using organumator.Dtos;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Repositories
{
    public class VacuumCleaningsRepository(ApplicationDbContext applicationDbContext) : IVacuumCleaningsRepository
    {
        public async Task<VacuumCleanings> AddVacuumCleaningsAsync(VacuumCleanings vacuumCleanings)
        {
            applicationDbContext.VacuumCleanings.Add(vacuumCleanings);
            await applicationDbContext.SaveChangesAsync();
            return vacuumCleanings;
        }

        public async Task DeleteVacuumCleaningsAsync(int id)
        {
            var vacuumCleanings = await applicationDbContext.VacuumCleanings.FirstOrDefaultAsync(x => x.Id == id);
            if (vacuumCleanings == null) return;
            applicationDbContext.VacuumCleanings.Remove(vacuumCleanings);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<VacuumCleanings>> GetAllVacuumCleaningsPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await applicationDbContext.VacuumCleanings.CountAsync();
            var items = await applicationDbContext.VacuumCleanings
                .OrderByDescending(x => x.PerformedOnDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<VacuumCleanings>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<VacuumCleanings> GetVacuumCleaningsByIdAsync(int id)
        {
            var vacuumCleanings = await applicationDbContext.VacuumCleanings.FirstOrDefaultAsync(x => x.Id == id);
            return vacuumCleanings switch
            {
                null => throw new Exception($"VacuumCleanings with id {id} not found."),
                _ => vacuumCleanings
            };
        }

        public async Task<VacuumCleanings> UpdateVacuumCleaningsAsync(VacuumCleanings vacuumCleanings)
        {
            var existingVacuumCleanings = await applicationDbContext.VacuumCleanings.FirstOrDefaultAsync(x => x.Id == vacuumCleanings.Id);
            if (existingVacuumCleanings == null)
            {
                throw new Exception($"VacuumCleanings with id {vacuumCleanings.Id} not found.");
            }
            existingVacuumCleanings.PerformedOnDate = vacuumCleanings.PerformedOnDate;
            await applicationDbContext.SaveChangesAsync();
            return existingVacuumCleanings;
        }
    }
}