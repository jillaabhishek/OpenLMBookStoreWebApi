using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Entities
{
    public class Order
    {
        public string OrderId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalAmount { get; set; }

        public string BookId { get; set; }

        public Book Book { get; set; }

        public Address Address { get; set; }
    }
}
