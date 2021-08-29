using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Dtos
{
    public class BookModel
    {
        public string BookId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        //[MinLength(1, ErrorMessage ="Book price should be greater than zero")]
        //[MaxLength(1000, ErrorMessage ="Book price can't be greater than 1000")]
        [Range(1, 1000, ErrorMessage ="Book price should range be 1 to 1000")]
        public decimal Price { get; set; }

        [Required]        
        public string Description { get; set; }
        
        //[Required]        
        public byte[] BookCoverImage { get; set; }
        
        [Required]        
        public BookCategory Category { get; set; }
        
        [Required]
        public Binding BookBinding { get; set; }
        
        [Required]
        //[MinLength(50, ErrorMessage = "No of pages in book should be greater than 50 pages")]
        //[MaxLength(2000, ErrorMessage = "No of pages in book can't be greater than 2000 pages")]
        [Range(1, 1000, ErrorMessage = "Book pages range should be 1 to 1000")]
        public int NoOfPages { get; set; }
        
        [Required]
        public string Language { get; set; }
        
        [Required]
        //[MinLength(1, ErrorMessage = "Book quantity should be greater than zero")]
        //[MaxLength(10000, ErrorMessage = "Book quantity can't be greater than 10000")]
        [Range(1, 1000, ErrorMessage = "Book quantity range should be 1 to 10000")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Required]
        public bool IsBookBestSeller { get; set; }

        public AuthorModel Author { get; set; }

        public PublisherModel Publisher { get; set; }
    }

    public enum Binding
    {
        Paperback,
        Hardcover,
        Online
    }

    public enum BookCategory
    {
        General,
        Comics,
        Cooking,
        Horror,
        Kids,
        Fictional,
        SciFiAndFantasy,
        Biographies
    }

}
