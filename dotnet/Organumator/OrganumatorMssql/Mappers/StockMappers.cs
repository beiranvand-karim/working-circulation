namespace OrganumatorMssql.Mappers
{
    public static class StockMappers
    {
        public static Dtos.Stock.StockDto ToStockDto(this Models.Stock stock)
        {
            return new Dtos.Stock.StockDto
            {
                Id = stock.Id,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                LastDividend = stock.LastDividend,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap,
                Symbol = stock.Symbol,
                Comments = stock.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Models.Stock ToStock(this Dtos.Stock.CreateStockRequestDto stockDto)
        {
            return new Models.Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDividend = stockDto.LastDividend,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
    }
}