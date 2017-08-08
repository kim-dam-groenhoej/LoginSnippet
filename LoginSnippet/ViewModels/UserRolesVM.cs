using LoginSnippet.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginSnippet.ViewModels
{
    public class UserRolesVM
    {
        public List<ApplicationUser> Users { get; set; }

        public List<IdentityRole> Roles { get; set; }
    }
}