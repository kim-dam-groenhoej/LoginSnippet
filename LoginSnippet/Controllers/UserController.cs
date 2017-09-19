using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSnippet.Models;
using LoginSnippet.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LoginSnippet.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context;
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserController()
        {
            this.context = new ApplicationDbContext();
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            this.roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public ActionResult Index()
        {
            var vm = new UserVM();
            vm.ApplicationUser = userManager.FindById(User.Identity.GetUserId());

            // test code
            if (!this.roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole("admin");
                this.roleManager.Create(role);

                this.userManager.AddToRole(User.Identity.GetUserId(), role.Name);
            }
            else
            {
                var role = this.roleManager.FindByName("admin");
                this.userManager.AddToRole(User.Identity.GetUserId(), role.Name);
            }

            vm.Roles = this.userManager.GetRoles(User.Identity.GetUserId()).ToList();
            
            return View(vm);
        }
    }
}