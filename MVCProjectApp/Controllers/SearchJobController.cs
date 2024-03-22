using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProjectApp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace MVCProjectApp.Controllers
{
    public class SearchJobController : Controller
    {
        // GET: SearchJob
        DbMVCprojectEntities dbobj = new DbMVCprojectEntities();
        public ActionResult Jobsearchload()
        {
            return View(GetData());
        }
        private Jobsearch GetData()
        {
            var joblist = new Jobsearch();
            List<string> lst = new List<string>();
            var job = dbobj.Jobs_Tab.ToList();//get values from Db
            foreach (var e in job)//set values to model class using insert and select
            {
                var tabcls = new tabclass();
                tabcls.Job_Id = e.Job_Id;
                tabcls.Comp_id = e.Comp_id;
                tabcls.Job_Title = e.Job_Title;
                tabcls.Skills = e.Skills;
                tabcls.Experience = e.Experience;
                tabcls.Job_Status = e.Job_Status;
                tabcls.Last_Date = e.Last_Date;
                joblist.selectobj.Add(tabcls);
                var s = tabcls.Skills;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
            }
            return joblist;
        }

        public ActionResult Searchjob_click(Jobsearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.searchobj.Experience))
            {
                qry += " and Experience like '%" + clsobj.searchobj.Experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.searchobj.Skills))
            {
                qry += " and Skills like '%" + clsobj.searchobj.Skills + "%'";
            }

            return View("Jobsearchload",Getdata1(clsobj, qry));
        }
        public Jobsearch Getdata1(Jobsearch clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("sp_check", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new Jobsearch();
                while (dr.Read())
                {
                    var tabcls = new tabclass();
                    //tabcls.Job_Id = e.Job_Id;
                    tabcls.Comp_id = Convert.ToInt32(dr["Comp_id"].ToString());
                    tabcls.Job_Title = dr["Job_Title"].ToString();
                    tabcls.Skills = dr["Skills"].ToString();
                    tabcls.Experience = dr["Experience"].ToString();
                    tabcls.Job_Status = dr["Job_Status"].ToString();
                    tabcls.Last_Date = dr["Last_Date"].ToString();
                    joblist.selectobj.Add(tabcls);
                }
                con.Close();
                return joblist;

            }
        }
    }
}
