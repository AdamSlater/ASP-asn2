using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using DiplomaDataModel.Models;
using Microsoft.AspNet.Identity;
using DiplomaDataModel.Controllers;
using DiplomaDataModel;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace OptionsWebSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private object _userManager;

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var x = collection["RoleName"];

            if (collection["RoleName"] == "")
            {
                ViewBag.ResultMessage = "Invalid Role!";
                ViewBag.messageFlag = 1;
                return View("Index", db.Roles.ToList());
            }

            try
            {
                db.Roles.Add(new IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                db.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                ViewBag.messageFlag = 0;
                return View("Index", db.Roles.ToList());
            }
            catch
            {
                ViewBag.ResultMessage = "Already Exist";
                ViewBag.messageFlag = 1;
                return View("Index", db.Roles.ToList());
            }
        }

        public ActionResult Delete(string RoleName)
        {
            var thisRole = db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            db.Roles.Remove(thisRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Roles/Edit/5
        public ActionResult Edit(string roleName)
        {
            var thisRole = db.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {   //cast to match the type of this context
                return (ApplicationUserManager) _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }



        public ActionResult ManageUserRoles()
        {
            // prepopulate roles for the view dropdown
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                        new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            var userList = db.Users.Select(c => new SelectListItem { Value = c.UserName.ToString() , Text = c.UserName.ToString() });


            ViewBag.Users = userList;
            ViewBag.Roles = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {



            ViewBag.ResultMessage = "Invalid Value!";
            ViewBag.messageFlag = 1;

            if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(RoleName))
            {
                ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                UserManager.AddToRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Role added successfully !";
                ViewBag.messageFlag = 0;
            }
            // prepopulate roles for the view dropdown
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            var userList = db.Users.Select(c => new SelectListItem { Value = c.UserName.ToString(), Text = c.UserName.ToString() });
            ViewBag.Roles = list;
            ViewBag.Users = userList;
 

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            ViewBag.ResultMessage = "Invalid Value!";
            ViewBag.messageFlag = 1;
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
             
                ViewBag.RolesForThisUser = UserManager.GetRoles(user.Id);
                ViewBag.userName = user.UserName;
                ViewBag.messageFlag = null;
                //// prepopulate roles for the view dropdown
                //var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                //var userList = db.Users.Select(c => new SelectListItem { Value = c.UserName.ToString(), Text = c.UserName.ToString() });
                //ViewBag.Roles = list;
                //ViewBag.Users = userList;
            }

            // prepopulate roles for the view dropdown
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            var userList = db.Users.Select(c => new SelectListItem { Value = c.UserName.ToString(), Text = c.UserName.ToString() });
            ViewBag.Roles = list;
            ViewBag.Users = userList;

            return View("ManageUserRoles");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string[] RoleName)
        {
            ViewBag.ResultMessage = "Invalid Value!";
            ViewBag.messageFlag = 1;

            if (!string.IsNullOrWhiteSpace(UserName) && RoleName != null)
            {
                ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                foreach(var role in RoleName)
                {
                    if (UserManager.IsInRole(user.Id, role))
                    {
                        UserManager.RemoveFromRole(user.Id, role);
                        ViewBag.ResultMessage = "Role removed from this user successfully !";
                        ViewBag.messageFlag = 0;
                    }
                    else
                    {
                        ViewBag.ResultMessage = "This user doesn't belong to selected role.";
                        ViewBag.messageFlag = 1;
                    }
                }
                
            }
            // prepopulate roles for the view dropdown
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            var userList = db.Users.Select(c => new SelectListItem { Value = c.UserName.ToString(), Text = c.UserName.ToString() });
            ViewBag.Roles = list;
            ViewBag.Users = userList;

            return View("ManageUserRoles");
        }
    }


}