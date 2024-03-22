using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCProjectApp.Models
{

    public class UserInsert
    {
        public int User_Id { get; set; }
        [Required(ErrorMessage = "Enter the name")]
        public string Name { get; set; }
        [Range(18, 50, ErrorMessage = "Enter the age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter the address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter the Phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Enter the email id")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter the Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Enter the Qualification")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Enter the Experience")]
        public string Experience { get; set; }
        [Required(ErrorMessage = "Enter the skills")]
        public string Skills { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        [Compare("pass", ErrorMessage = "Password mismatch")]
        public string cpassword { get; set; }
        public string usermsg { get; set; }

    }
}