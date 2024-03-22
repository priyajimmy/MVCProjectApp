using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCProjectApp.Models;

namespace MVCProjectApp.Controllers
{
    public class ApplyCVController : Controller
    {
        DbMVCprojectEntities dbobj = new DbMVCprojectEntities();
        // GET: ApplyCV
        public ActionResult ApplyCV_Load(int cid,int jid)
        {
            TempData["cid"] = cid;
            TempData["jid"] = jid;
            return View();
        }
        public ActionResult Applyclick_Load(cvinsert clsobj,Jobsearch obj,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Photos");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~/Photos", fname);
                    clsobj.Resume = fullpath;
                }
                dbobj.sp_applycv(Convert.ToInt32(Session["uid"]), Convert.ToInt32(TempData["jid"]), clsobj.Resume, DateTime.Now.ToString(clsobj.App_Date),"submitted");
                clsobj.App_msg = "Application Submitted";
                return View("ApplyCV_Load", clsobj);
            }
            return View("ApplyCV_Load", clsobj);
        }
    }
}