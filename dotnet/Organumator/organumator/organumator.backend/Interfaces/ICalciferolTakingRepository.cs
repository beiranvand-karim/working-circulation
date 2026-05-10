using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organumator.Interfaces
{
    public interface ICalciferolTakingRepository
    {
        Task<IEnumerable<Models.CalciferolTakingModel>> GetAllAsync();
        Task<Models.CalciferolTakingModel> GetByIdAsync(int id);
        Task AddAsync(Models.CalciferolTakingModel calciferolTakingModel);
        Task UpdateAsync(Models.CalciferolTakingModel calciferolTakingModel);
        Task DeleteAsync(int id);
    }
}