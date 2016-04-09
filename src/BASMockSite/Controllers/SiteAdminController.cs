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
using BASMockSite.ViewModels.Messages;

namespace BASMockSite.Controllers
{
    [Authorize(Roles = "SiteAdmin")]
    public class SiteAdminController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public SiteAdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: AdminMenuIndex        
        public IActionResult Index(OperationMsg opMsg)
        {
            if (opMsg != null)
            {
                if (opMsg.OperationSuccessful)
                    ViewBag.SuccessMsg = opMsg.Message;
                else
                    ViewBag.FailMsg = opMsg.Message;
            }
            else
            {
                ViewBag.SuccessMsg = null;
                ViewBag.FailMsg = null;
            }
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
                        return RedirectToAction("Index", new SuccessMsg("The role was created successfully."));
                    else
                        return RedirectToAction("Index", new FailureMsg("The role was unable to be created."));
                case "Remove":
                    IdentityRole roleToRemove = await _roleManager.FindByNameAsync(roleName);
                    if (roleToRemove != null)
                    {
                        var removeResult = await _roleManager.DeleteAsync(roleToRemove);
                        if (removeResult.Succeeded)
                            return RedirectToAction("Index", new SuccessMsg("The role was successfully deleted."));
                        else
                            return RedirectToAction("Index", new FailureMsg("The role was unable to be deleted."));
                    }
                    return RedirectToAction("Index", new FailureMsg("The role you are trying to remove does not exist."));
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

        // switching on btnAddOrRemove means that the view is tightly coupled
        // The view must have inputs with values Add and Remove.
        // This could potentially be refactored into multiple methods, one for each case
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRemoveUserRole(AddRemoveUserRoleViewModel viewModel, string btnAddOrRemove)
        {            
            var user = _context.Users.Where(u => u.UserName == viewModel.UsersName).FirstOrDefault();
            var assignedRole = _context.Roles.Where(r => r.Id.ToString() == viewModel.UsersRoleID).FirstOrDefault();
            if (user != null && assignedRole != null)
            {
                switch (btnAddOrRemove)
                {
                    case "Add":
                        var result = await _userManager.AddToRoleAsync(user, assignedRole.Name);

                        if (result.Succeeded)
                            return RedirectToAction("Index", new SuccessMsg(user.UserName + " was successfully added to the role " + assignedRole.Name + "."));
                        else
                            return RedirectToAction("Index", new FailureMsg("The user was unable to be assigned to that role, or maybe they've already been assigned."));
                    case "Remove":
                        var removeResult = await _userManager.RemoveFromRoleAsync(user, assignedRole.Name);

                        if (removeResult.Succeeded)
                            return RedirectToAction("Index", new SuccessMsg(user.UserName + " was successfully removed from the role " + assignedRole.Name + "."));
                        else
                            return RedirectToAction("Index", new FailureMsg("Unable to remove the user from this role."));
                    default:
                        break;
                }
                
            }
            return RedirectToAction("Index", new FailureMsg("An unexpected error occured, be sure to select a user and a role."));
        }

        // switching on btnAddOrRemove means that the view is tightly coupled
        // The view must have inputs with values Add and Remove.
        // This could potentially be refactored into multiple methods, one for each case
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
                        return RedirectToAction("Index", new SuccessMsg("The user has been associated with a BASManagerID."));
                    case "Remove":
                        user.BASManagerID = null;
                        _context.SaveChanges();
                        return RedirectToAction("Index", new SuccessMsg("The user has had their BASManagerID removed."));
                    default:
                        break;
                }
            }
            return RedirectToAction("Index", new FailureMsg("An unexpected error occured."));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUser(RemoveUserViewModel vm)
        {
            var user = await _userManager.FindByEmailAsync(vm.UserName);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index", new SuccessMsg("The user was successfully removed."));
            }

            return RedirectToAction("Index", new FailureMsg("Sorry, the user was not found, or was unabled to be deleted."));
        }
    }
}
