using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using OrganumatorMssql.Dtos.Comment;

namespace OrganumatorMssql.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        public decimal Purchase { get; set; }

        public decimal LastDividend { get; set; }

        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }

        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();

    }
}