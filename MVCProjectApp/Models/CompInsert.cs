using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCProjectApp.Models
{
    public class CompInsert
    {
        public int Comp_id { get; set; }
        [Required(ErrorMessage = "Enter the Company name")]
        public string Comp_Name { get; set; }
        [Required(ErrorMessage = "Enter the Company address")]
        public string Comp_Address { get; set; }
        [Required(ErrorMessage = "Enter the phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string Comp_Phone { get; set; }
        [Required(ErrorMessage = "Enter the Website address")]
        public string Comp_Web { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        [Compare("pass", ErrorMessage = "Password mismatch")]
        public string cpassword { get; set; }
        public string Compmsg { get; set; }
    }
}