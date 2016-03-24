using DiplomaDataModel;
using DiplomaDataModel.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OptionsWebSite.Controllers
{
    public class UsersController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        // GET: User
        public ActionResult Index()
        {
            ViewBag.UserList = db.Users.ToList();
            return View();
        }

        //POST: enable/disable user 
        public JsonResult LockUser(string UserName, string flag)
        {
            var user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if(flag == "on")
            {
                user.LockoutEnabled = false;
            }
            else
            {
                user.LockoutEnabled = true;
            }
           
            db.SaveChanges();
            return Json(new { Result =  user.LockoutEnabled });
        }
    }
}