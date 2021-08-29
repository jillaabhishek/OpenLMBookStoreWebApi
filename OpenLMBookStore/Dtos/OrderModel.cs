using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Dtos
{
    public class OrderModel
    {
        public string OrderId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalAmount { get; set; }

        public string BookId { get; set; }

        public BookModel Book { get; set; }

        public AddressModel Address { get; set; }
    }
}
