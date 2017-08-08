using LoginSnippet.Models;
using LoginSnippet.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginSnippet.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddRoleToUser()
        {
            var context = new ApplicationDbContext();
            var vm = new UserRolesVM();

            vm.Users = context.Users.ToList();
            vm.Roles = context.Roles.ToList();

            return View(vm);
        }

        [HttpPost]
        public ActionResult AddRoleToUser(AddRoleToUserVM model)
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Add default User to Role Admin   
            userManager.AddToRole(model.UserID, roleManager.FindById(model.RoleID).Name);
   
            return View();
        }

        public ActionResult CreateRole(IdentityRole role)
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(role);

            return View();
        }
    }
}