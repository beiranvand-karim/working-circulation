using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDA_Customer.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ProductId { get; set; }
        public int ItemsInCart { get; set; }
    }
}