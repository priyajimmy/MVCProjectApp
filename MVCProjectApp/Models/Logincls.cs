using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCProjectApp.Models
{
    public class Logincls
    {

        [Required(ErrorMessage = "Enter the username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter the password")]
        public string Password { get; set; }
        public string msg { get; set; }
        public string ltype { get; set; }
    }
}