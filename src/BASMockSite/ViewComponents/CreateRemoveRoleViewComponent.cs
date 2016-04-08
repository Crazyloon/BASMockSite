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
    public class CreateRemoveRoleViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public CreateRemoveRoleViewComponent(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IViewComponentResult Invoke()
        {
            CreateRemoveRoleViewModel vm = new CreateRemoveRoleViewModel();
            return View(vm);
        }
    }
}
