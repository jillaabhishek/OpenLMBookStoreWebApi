using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Entities
{
    public class Book
    {
        public string BookId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] BookCoverImage { get; set; }
        public string Category { get; set; }        
        public string BookBinding { get; set; }
        public int NoOfPages { get; set; }
        public string Language { get; set; }
        public int Quantity { get; set; }
        public bool IsBookBestSeller { get; set; }

        public DateTime PublishedDate { get; set; }

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
    }
}
