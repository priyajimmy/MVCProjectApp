using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProjectApp.Models;
namespace MVCProjectApp.Controllers
{
    public class JobController : Controller
    {
        DbMVCprojectEntities dbobj = new DbMVCprojectEntities();
        // GET: Job
        public ActionResult InsertJob_Pageload()
        {
            return View();
        }
        public ActionResult InsertJob_click(jobs clsobj)
        {
            if (ModelState.IsValid)
            {
               
                //get
        dbobj.sp_jobs(Convert.ToInt32(Session["uid"]),clsobj.Job_Title, clsobj.Skills, clsobj.Experience, "available", DateTime.Now.ToString("yyyy-MM-dd"));
              
                clsobj.jobmsg = "successfully inserted";
                return View("InsertJob_Pageload", clsobj);
            }
            return View("InsertJob_Pageload", clsobj);
        }
    }
}