using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProjectApp.Models;
namespace MVCProjectApp.Controllers
{
    public class UserRegController : Controller
    {
        DbMVCprojectEntities dbobj = new DbMVCprojectEntities();
        // GET: UserReg
        public ActionResult InsertUser_Pageload()
        {
            return View();
        }
        public ActionResult InsertUser_click(UserInsert clsobj)
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
                dbobj.sp_userReg(regid, clsobj.Name, clsobj.Age, clsobj.Address, clsobj.Phone, clsobj.Email, clsobj.Gender, clsobj.Qualification, clsobj.Experience, clsobj.Skills);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "User");
                clsobj.usermsg = "successfully inserted";
                return View("InsertUser_Pageload", clsobj);
            }
            return View("InsertUser_Pageload", clsobj);

        }
    }
}