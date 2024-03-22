using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectApp.Models
{
    public class Jobsearch
    {
        public Jobsearch()
        {
            selectobj = new List<tabclass>();
            searchobj = new tabclass();
        }
        public tabclass searchobj { set; get; }
        public List<tabclass> selectobj { set; get; }
    }
    public class tabclass
    {
        public int Job_Id { get; set; }
        public int Comp_id { get; set; }
        public string Job_Title { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Job_Status { get; set; }
        public string Last_Date { get; set; }
    }
}