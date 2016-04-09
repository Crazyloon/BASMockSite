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
    public class RemoveUserViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public RemoveUserViewComponent(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IViewComponentResult Invoke()
        {
            List<ApplicationUser> users = _context.Users.ToList();

            RemoveUserViewModel vm = new RemoveUserViewModel();
            foreach (var user in users)
            {
                vm.Users.Add(new SelectListItem() { Text = user.Email, Value = user.Email });
            }
            if (vm.Users.Count > 0)
                vm.Users[0].Selected = true;

            return View(vm);
        }
    }
}
