using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCProjectApp.Models
{
    public class JobApply
    {
        
        [Required(ErrorMessage = "Enter the name")]
        public string Name { get; set; }
        [Range(18, 50, ErrorMessage = "Enter the age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter the address")]
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Enter the email id")]
        public string Email { get; set; }
        public string Photo { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        [Compare("pass", ErrorMessage = "Password mismatch")]
        public string cpassword { get; set; }
        public string usermsg { get; set; }

    }
}
    
