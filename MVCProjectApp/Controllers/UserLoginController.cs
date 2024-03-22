using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using MVCProjectApp.Models;
namespace MVCProjectApp.Controllers
{
    public class UserLoginController : Controller
    {
        DbMVCprojectEntities dbobj = new DbMVCprojectEntities();
        // GET: UserLogin
        public ActionResult Login_pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Login_Click(Logincls objcls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_Login(objcls.Username, objcls.Password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_loginId(objcls.Username, objcls.Password).FirstOrDefault();
                    Session["uid"] = uid;
                    var lt = dbobj.sp_loginType(objcls.Username, objcls.Password).FirstOrDefault();
                    if (lt == "User")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "admin")
                    {
                        return RedirectToAction("AdminHome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    objcls.msg = "Invalid Login";
                    return View("Login_pageload", objcls);
                }
            }
            return View("Login_pageload", objcls);
        }
    }
}