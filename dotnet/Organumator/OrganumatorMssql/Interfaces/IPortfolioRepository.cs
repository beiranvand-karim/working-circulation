using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrganumatorMssql.Models;

namespace OrganumatorMssql.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser appUser);
    }
}