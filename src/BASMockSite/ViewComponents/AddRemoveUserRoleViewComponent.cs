using BASMockSite.Models;
using BASMockSite.ViewModels.Administration;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.ViewComponents
{
    public class AddRemoveUserRoleViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public AddRemoveUserRoleViewComponent(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Create combo boxes for Users and Roles, Only Users who have BASManagerID's get added
            List<IdentityRole> roles = _context.Roles.ToList();
            List<ApplicationUser> users = _context.Users.ToList();

            AddRemoveUserRoleViewModel vm = new AddRemoveUserRoleViewModel();
            foreach (var role in roles)
            {
                vm.Roles.Add(new SelectListItem() { Text = role.Name, Value = role.Id });
            }
            if (vm.Roles.Count > 0)
                vm.Roles[0].Selected = true;
            foreach (var user in users)
            {
                vm.Users.Add(new SelectListItem() { Text = user.Email, Value = user.UserName });
            }
            if (vm.Users.Count > 0)
                vm.Users[0].Selected = true;
            return View(vm);
        }
    }
}
