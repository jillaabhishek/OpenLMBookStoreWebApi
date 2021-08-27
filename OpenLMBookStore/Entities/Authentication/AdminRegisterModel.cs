using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Entities.Authentication
{
    public class AdminRegisterModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Address is Required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Admin Type is Required")]
        public  AdminType AdminType { get; set; }
    }

    public enum AdminType { 
        Admin,
        Author,
        Publisher
    }
}
