using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Entities
{
    public class Author
    {
        public string AuthorId { get; set; }

        public string Name { get; set; }

        public Book[] Books { get; set; }

        //Awards can be added. Own by author
    }
}
