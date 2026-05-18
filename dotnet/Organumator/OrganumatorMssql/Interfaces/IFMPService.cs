using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrganumatorMssql.Models;

namespace OrganumatorMssql.Interfaces
{
    public interface IFMPService
    {
        Task<Stock> FindStockBySymbolAsync(string symbol);
    }
}