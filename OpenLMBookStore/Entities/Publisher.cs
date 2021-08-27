using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Entities
{
    public class Publisher
    {
        public string PublisherId { get; set; }

        public string PublisherName { get; set; }

        public DateTime PublishedDate { get; set; }

        public Book[] Books { get; set; }
    }
}
