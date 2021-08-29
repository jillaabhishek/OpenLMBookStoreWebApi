using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Dtos
{
    public class AddressModel
    {
        public string AddressId { get; set; }

        public string AddressStreet1 { get; set; }

        public string AddressStreet2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
