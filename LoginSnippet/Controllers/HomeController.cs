using LoginSnippet.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginSnippet.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            // all users
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            

            var users = userManager.Users;
            ViewBag.RoleManager = roleManager;
            ViewBag.Users = users.ToList();

            // Current user
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = HttpContext.User.Identity.GetUserId();
                var currentUser = userManager.Users.FirstOrDefault(u => u.Id == userId);
                ViewBag.CurrentUser = currentUser;
            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Employee")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}