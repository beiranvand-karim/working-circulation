using Microsoft.EntityFrameworkCore;
using OrganumatorMssql.Data;
using OrganumatorMssql.Dtos.Stock;
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

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _applicationDbContext.Stocks.Include(s => s.Comments).ToListAsync();
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