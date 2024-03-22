using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProjectApp.Models;
namespace MVCProjectApp.Controllers
{
    public class CompanyRegController : Controller
    {
        DbMVCprojectEntities dbobj = new DbMVCprojectEntities();
        // GET: CompanyReg
        public ActionResult InsertCompany_Pageload()
        {
            return View();
        }
        public ActionResult InsertCompany_click(CompInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                //get
                dbobj.sp_CompReg(regid, clsobj.Comp_Name, clsobj.Comp_Address, clsobj.Comp_Phone, clsobj.Comp_Web);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "admin");
                clsobj.Compmsg = "successfully inserted";
                return View("InsertCompany_Pageload", clsobj);
            }
            return View("InsertCompany_Pageload", clsobj);
        }
    }
}