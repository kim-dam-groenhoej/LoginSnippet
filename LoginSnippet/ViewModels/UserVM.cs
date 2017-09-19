using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginSnippet.Models;

namespace LoginSnippet.ViewModels
{
    public class UserVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List<string> Roles { get; set; }
    }
}