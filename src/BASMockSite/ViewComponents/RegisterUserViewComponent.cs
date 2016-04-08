using BASMockSite.Models;
using BASMockSite.ViewModels.Account;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.ViewComponents
{
    public class RegisterUserViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public RegisterUserViewComponent(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IViewComponentResult Invoke()
        {
            RegisterViewModel vm = new RegisterViewModel();
            return View(vm);
        }
    }
}
