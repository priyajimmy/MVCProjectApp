using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProjectApp.Models;
namespace MVCProjectApp.Controllers
{
    public class ProfileDBController : Controller
    {
        DbMVCprojectEntities dbobj = new DbMVCprojectEntities();
        // GET: ProfileDB
        public ActionResult Profile_Load()
        {
            var getdata = dbobj.sp_userprofile(Convert.ToInt32(Session["Uid"])).FirstOrDefault();
            return View(new UserProfilecls
            {
                name = getdata.Name,
                age = getdata.Age,
                address = getdata.Address,
                phone = getdata.Phone,
                email = getdata.Email,
                gender=getdata.Gender,
                qualification=getdata.Qualification,
                experience=getdata.Experience,
                skills=getdata.Skills

            });

         
        }
    }
}