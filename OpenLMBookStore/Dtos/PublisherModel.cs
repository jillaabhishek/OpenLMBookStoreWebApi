using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Dtos
{
    public class PublisherModel
    {
        public string PublisherId { get; set; }

        [Required]
        public string PublisherName { get; set; }
    }
}
