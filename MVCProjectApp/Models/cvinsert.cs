using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectApp.Models
{
    public class cvinsert
    {
        public int App_Id { get; set; }
        public int User_Id { get; set; }
        public int Job_Id { get; set; }
        public string Resume { get; set; }
        public string App_Date { get; set; }
        public string App_status { get; set; }
        public string App_msg { get; set; }
    }
}