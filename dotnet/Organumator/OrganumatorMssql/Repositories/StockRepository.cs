using Microsoft.EntityFrameworkCore;
using OrganumatorMssql.Data;
using OrganumatorMssql.Dtos.Stock;
using OrganumatorMssql.Helpers;
using OrganumatorMssql.Interfaces;
using OrganumatorMssql.Models;

namespace OrganumatorMssql.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StockRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {

            await _applicationDbContext.Stocks.AddAsync(stock);
            await _applicationDbContext.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _applicationDbContext.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return null;
            }
            _applicationDbContext.Stocks.Remove(stock);
            await _applicationDbContext.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject queryObject)
        {
            var stocks = _applicationDbContext.Stocks.Include(s => s.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryObject.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(queryObject.CompanyName));

            }

            if (!string.IsNullOrWhiteSpace(queryObject.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(queryObject.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(queryObject.Symbol));

                if (queryObject.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = queryObject.IsDescending
                        ? stocks.OrderByDescending(s => s.Symbol)
                        : stocks.OrderBy(s => s.Symbol);
                }
            }

            var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;

            return await stocks.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();

        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task<bool> StockExists(int id)
        {
            return _applicationDbContext.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
        {

            var stockToUpdate = _applicationDbContext.Stocks.FirstOrDefault(s => s.Id == id);
            if (stockToUpdate == null)
            {
                return null;
            }
            stockToUpdate.Symbol = updateStockRequestDto.Symbol;
            stockToUpdate.CompanyName = updateStockRequestDto.CompanyName;
            stockToUpdate.Purchase = updateStockRequestDto.Purchase;
            stockToUpdate.LastDividend = updateStockRequestDto.LastDividend;
            stockToUpdate.Industry = updateStockRequestDto.Industry;
            stockToUpdate.MarketCap = updateStockRequestDto.MarketCap;

            await _applicationDbContext.SaveChangesAsync();
            return stockToUpdate;
        }
    }
}