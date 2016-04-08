using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using BASMockSite.Models;

namespace BASMockSite.ViewModels.Administration
{
    public class AddRemoveUserRoleViewModel
    {
        public AddRemoveUserRoleViewModel()
        {
            Users = new List<SelectListItem>();
            Roles = new List<SelectListItem>();
        }

        public string UsersName { get; set; }
        public string UsersRoleID { get; set; }

        public List<string> UserRoles { get; set; }

        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
