using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace OrganumatorMssql.Models
{
    public class Comment
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
         public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? StockId { get; set; }

        public Stock? Stock { get; set; }

    }
}