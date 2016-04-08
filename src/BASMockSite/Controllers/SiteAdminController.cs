using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;
using BASMockSite.ViewModels.BASManagers;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using BASMockSite.ViewModels.Administration;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BASMockSite.Controllers
{
    [Authorize(Roles = "SiteAdmin")]
    public class SiteAdminController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public SiteAdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: AdminMenuIndex        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRemoveRole(CreateRemoveRoleViewModel vm, string btnCreateOrRemove)
        {
            string roleName = vm.RoleName;
            
            switch (btnCreateOrRemove)
            {
                case "Create":
                    var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    break;
                case "Remove":
                    IdentityRole roleToRemove = await _roleManager.FindByNameAsync(roleName);
                    if (roleToRemove != null)
                    {
                        var removeResult = await _roleManager.DeleteAsync(roleToRemove);
                        if (removeResult.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    break;
            }
            return RedirectToAction("Index");
        }

        //// GET: AddUserToRole
        //public IActionResult AddUserToRole()
        //{
        //    // Create combo boxes for Users and Roles, Only Users who have BASManagerID's get added
        //    List<IdentityRole> roles = _context.Roles.ToList();
        //    List<ApplicationUser> users = _context.Users.ToList();

        //    AddUserToRoleViewModel vm = new AddUserToRoleViewModel();
        //    foreach (var role in roles)
        //    {
        //        vm.Roles.Add(new SelectListItem() { Text = role.Name, Value = role.Id });                
        //    }
        //    if (vm.Roles.Count > 0)
        //        vm.Roles[0].Selected = true;
        //    foreach (var user in users)
        //    {
        //        vm.Users.Add(new SelectListItem() { Text = user.Email, Value = user.UserName });                
        //    }
        //    if (vm.Users.Count > 0)
        //        vm.Users[0].Selected = true;

        //    return ViewComponent("AddUserToRole");
        //}


        // POST: AddUserToRole

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRemoveUserRole(AddRemoveUserRoleViewModel viewModel, string btnAddOrRemove)
        {            
            var user = _context.Users.Where(u => u.UserName == viewModel.UsersName).FirstOrDefault();
            var assignedRole = _context.Roles.Where(r => r.Id.ToString() == viewModel.UsersRoleID).FirstOrDefault();
            //RoleManager<IdentityRole> rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context),null,null,null,null,null);
            if (user != null && assignedRole != null)
            {
                switch (btnAddOrRemove)
                {
                    case "Add":
                        var result = await _userManager.AddToRoleAsync(user, assignedRole.Name);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            // send user some sort of error message
                        }
                        break;
                    case "Remove":
                        var removeResult = await _userManager.RemoveFromRoleAsync(user, assignedRole.Name);

                        if (removeResult.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            // send user some sort of error message
                        }
                        break;
                    default:
                        break;
                }
                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetUsersManagerID(SetUsersManagerIDViewModel vm, string btnAddOrRemove)
        {
            var user = _context.Users.Where(u => u.UserName == vm.User).FirstOrDefault();
            int mgrID;
            if (int.TryParse(vm.BASManagerID, out mgrID))
            {
                switch (btnAddOrRemove)
                {
                    case "Add":
                        user.BASManagerID = mgrID;
                        _context.SaveChanges();
                        break;
                    case "Remove":
                        user.BASManagerID = null;
                        _context.SaveChanges();
                        break;
                    default:
                        break;
                }
            }

            return RedirectToAction("Index");
        }
    }
}
