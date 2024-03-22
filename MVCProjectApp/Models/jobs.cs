using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCProjectApp.Models
{
    public class jobs
    {
        public int Job_Id { get; set; }
        public int Comp_id { get; set; }
        [Required(ErrorMessage = "Enter the job title")]
        public string Job_Title { get; set; }
        [Required(ErrorMessage = "Enter the skills")]
        public string Skills { get; set; }
        [Required(ErrorMessage = "Enter the experience")]
        public string Experience { get; set; }
        public string Job_Status { get; set; }
        //[Required(ErrorMessage = "Enter the last date")]
        public string Last_Date { get; set; }
        public string jobmsg { get; set; }
    }
}