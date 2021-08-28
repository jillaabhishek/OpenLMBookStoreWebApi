using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Dtos
{
    public class AuthorModel
    {
        public string AuthorId { get; set; }

        [Required]
        public string Name { get; set; }

        public BookModel[] Books { get; set; }
    }
}
