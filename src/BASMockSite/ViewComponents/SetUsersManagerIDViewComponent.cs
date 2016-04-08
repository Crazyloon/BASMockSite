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
    public class SetUsersManagerIDViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public SetUsersManagerIDViewComponent(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Create combo boxes for Users and Roles, Only Users who have BASManagerID's get added
            List<BASMockSite.Models.ProgramManager> BASManagers = _context.ProgramManagers.ToList();
            List<ApplicationUser> users = _context.Users.ToList();

            SetUsersManagerIDViewModel vm = new SetUsersManagerIDViewModel();
            foreach (var user in users)
            {
                vm.Users.Add(new SelectListItem() { Text = user.Email, Value = user.Email });
            }
            if (vm.Users.Count > 0)
                vm.Users[0].Selected = true;

            foreach (var mgr in BASManagers)
            {
                vm.BASManagers.Add(new SelectListItem() { Text = mgr.Name, Value = mgr.ManagerID.ToString() });
            }
            if (vm.BASManagers.Count > 0)
                vm.BASManagers[0].Selected = true;

            return View(vm);
        }
    }
}
